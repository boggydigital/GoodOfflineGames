﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using GOG.Interfaces;

namespace GOG.Controllers
{
    public class GOGDataController: IStringGetController
    {
        private const string gogDataPrefix = "var gogData = ";
        private Regex regex = new Regex(gogDataPrefix + "(.*)");
        private IStringGetController stringRequestController;

        public GOGDataController(IStringGetController stringRequestController)
        {
            this.stringRequestController = stringRequestController;
        }

        public async Task<string> GetString(string uri, IDictionary<string, string> parameters = null)
        {
            var gamePageContent = await stringRequestController.GetString(uri);

            var match = regex.Match(gamePageContent);
            string gogDataString = match.Value.Substring(
                gogDataPrefix.Length, // drop the prefix var gogData = 
                match.Value.Length - gogDataPrefix.Length - 1); // and closing ";"

            return gogDataString;
        }
    }
}