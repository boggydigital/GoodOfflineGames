﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Interfaces.Enumeration;
using Interfaces.Directory;
using Interfaces.Destination.Directory;
using Interfaces.Status;

namespace Controllers.Enumeration
{
    public class ProductFilesDirectoriesEnumerateAllDelegate : IEnumerateAllAsyncDelegate<string>
    {
        private IGetDirectoryDelegate productFilesDirectoryDelegate;
        private IDirectoryController directoryController;
        private IStatusController statusController;

        public ProductFilesDirectoriesEnumerateAllDelegate(
            IGetDirectoryDelegate productFilesDirectoryDelegate,
            IDirectoryController directoryController,
            IStatusController statusController)
        {
            this.productFilesDirectoryDelegate = productFilesDirectoryDelegate;
            this.directoryController = directoryController;
            this.statusController = statusController;
        }

        public async Task<IEnumerable<string>> EnumerateAllAsync(IStatus status)
        {
            var enumerateProductFilesDirectoriesTask = await statusController.CreateAsync(status, "Enumerate productFiles directories");

            var directories = new List<string>();

            await Task.Run(() =>
            {
                var productFilesDirectory = productFilesDirectoryDelegate.GetDirectory();
                directories.AddRange(directoryController.EnumerateDirectories(productFilesDirectory));
            });

            await statusController.CompleteAsync(enumerateProductFilesDirectoriesTask);

            return directories;
        }
    }
}
