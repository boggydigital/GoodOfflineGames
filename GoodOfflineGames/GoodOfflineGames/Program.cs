﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOG
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleController = new ConsoleController();
            var ioController = new IOController();
            var storage = new StorageController(ioController);

            var jsonDataPrefix = "var data = ";
            var filename = "data.js";
            ProductsResult storedGames = null;

            try
            {
                var storedGamesJson = storage.Pull(filename)
                    .Result
                    .Replace(jsonDataPrefix, string.Empty);
                storedGames = JSONController.Parse<ProductsResult>(storedGamesJson);
            }
            catch
            {
                // file not found or couldn't be read
                storedGames = new ProductsResult();
            }

            var settings = SettingsController.LoadSettings(consoleController, ioController).Result;

            AuthenticationController.AuthorizeOnSite(settings, consoleController).Wait();

            //storedGames.UpdateProductsDetails().Wait();

            // get all available games from gog.com/games

            var gamesResult = ProductsResultController.RequestUpdated(storedGames,
                Urls.GamesAjaxFiltered,
                QueryParameters.GamesAjaxFiltered,
                consoleController,
                "Getting all games available on GOG.com...").Result;

            // update product data from game pages

            //gamesResult.UpdateProductData(consoleController).Wait();

            // get all owned games from gog.com/account

            // filter owned products, so that we can check if account has got new owned games,
            // and not just new games, also this is critical as we mark games as owned later
            var storedOwned = new ProductsResult();
            storedOwned.Products = storedGames.Products.FindAll(p => p.Owned);

            var ownedResult = ProductsResultController.RequestUpdated(storedOwned,
                Urls.AccountGetFilteredProducts,
                QueryParameters.AccountGetFilteredProducts,
                consoleController,
                "Getting account games...").Result;

            // mark all new owned games as owned
            var ownedResultController = new ProductsResultController(ownedResult);
            ownedResultController.MarkAllAsOwned();

            // merge owned games into all available games 

            var gamesResultController = new ProductsResultController(gamesResult);
            gamesResultController.MergeOwned(ownedResult);

            // update game details for all owned games

            var gameDetailsController = new GameDetailsController(gamesResult);
            gameDetailsController.UpdateGameDetails(consoleController).Wait();

            // serialize and save on disk

            var gamesResultJson = "var data = " + JSONController.Stringify(gamesResult);
            storage.Put(filename, gamesResultJson).Wait();

            // download new images 
            var images = new ImagesController(ioController, consoleController);
            images.Update(gamesResult).Wait();

            // nothing left to do here

            Console.WriteLine("All done. Press ENTER to quit...");
            Console.ReadLine();
        }
    }

    #region Console controller

    class ConsoleController : IConsoleController
    {
        public string Read()
        {
            return Console.Read().ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string ReadPrivateLine()
        {
            ConsoleKeyInfo key;
            string privateData = string.Empty;
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                privateData += key.KeyChar;
            }
            return privateData;
        }

        public void Write(string message, params object[] data)
        {
            Console.Write(message, data);
        }

        public void WriteLine(string message, params object[] data)
        {
            Console.WriteLine(message, data);
        }
    }

    #endregion

    #region IOController

    class IOController : IIOController
    {
        public Stream OpenReadable(string uri)
        {
            return new FileStream(uri, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public Stream OpenWritable(string uri)
        {
            return new FileStream(uri, FileMode.Create, FileAccess.Write, FileShare.Read);
        }

        public bool ExistsFile(string uri)
        {
            return File.Exists(uri);
        }

        public bool ExistsDirectory(string uri)
        {
            return Directory.Exists(uri);
        }

        public void CreateDirectory(string uri)
        {
            Directory.CreateDirectory(uri);
        }
    }

    #endregion

}
