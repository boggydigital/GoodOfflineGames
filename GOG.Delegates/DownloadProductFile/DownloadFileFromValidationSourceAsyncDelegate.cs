﻿using System.IO;
using System.Threading.Tasks;
using Interfaces.Delegates.GetDirectory;
using Interfaces.Delegates.Format;
using Interfaces.Delegates.Confirm;
using Interfaces.Delegates.Download;
using Interfaces.Delegates.Activities;
using Attributes;
using GOG.Interfaces.Delegates.DownloadProductFile;
using Delegates.Format.Uri;
using Delegates.Confirm.Validation;
using Delegates.GetDirectory.ProductTypes;
using Delegates.Download;
using Delegates.Activities;

namespace GOG.Delegates.DownloadProductFile
{
    public class DownloadValidationFileAsyncDelegate : IDownloadProductFileAsyncDelegate
    {
        private readonly IFormatDelegate<string, string> formatUriRemoveSessionDelegate;
        private readonly IConfirmDelegate<string> confirmValidationExpectedDelegate;
        private readonly IFormatDelegate<string, string> formatValidationFileDelegate;
        private readonly IGetDirectoryDelegate validationDirectoryDelegate;
        private readonly IFormatDelegate<string, string> formatValidationUriDelegate;
        private readonly IDownloadFromUriAsyncDelegate downloadFromUriAsyncDelegate;
        private readonly IStartDelegate startDelegate;
        private readonly ICompleteDelegate completeDelegate;

        [Dependencies(
            typeof(FormatUriRemoveSessionDelegate),
            typeof(ConfirmFileValidationSupportedDelegate),
            typeof(FormatValidationFileDelegate),
            typeof(GetMd5DirectoryDelegate),
            typeof(FormatValidationUriDelegate),
            typeof(DownloadFromUriAsyncDelegate),
            typeof(StartDelegate),
            typeof(CompleteDelegate))]
        public DownloadValidationFileAsyncDelegate(
            IFormatDelegate<string, string> formatUriRemoveSessionDelegate,
            IConfirmDelegate<string> confirmValidationExpectedDelegate,
            IFormatDelegate<string, string> formatValidationFileDelegate,
            IGetDirectoryDelegate validationDirectoryDelegate,
            IFormatDelegate<string, string> formatValidationUriDelegate,
            IDownloadFromUriAsyncDelegate downloadFromUriAsyncDelegate,
            IStartDelegate startDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.formatUriRemoveSessionDelegate = formatUriRemoveSessionDelegate;
            this.confirmValidationExpectedDelegate = confirmValidationExpectedDelegate;
            this.formatValidationFileDelegate = formatValidationFileDelegate;
            this.validationDirectoryDelegate = validationDirectoryDelegate;
            this.formatValidationUriDelegate = formatValidationUriDelegate;
            this.downloadFromUriAsyncDelegate = downloadFromUriAsyncDelegate;
            this.startDelegate = startDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task DownloadProductFileAsync(long id, string title, string sourceUri, string destination)
        {
            if (string.IsNullOrEmpty(sourceUri)) return;

            var sourceUriSansSession = formatUriRemoveSessionDelegate.Format(sourceUri);
            var destinationUri = formatValidationFileDelegate.Format(sourceUriSansSession);

            // return early if validation is not expected for this file
            if (!confirmValidationExpectedDelegate.Confirm(sourceUriSansSession)) return;

            if (File.Exists(destinationUri))
                // await statusController.InformAsync(status, "Validation file already exists, will not be redownloading");
                return;

            var validationSourceUri = formatValidationUriDelegate.Format(sourceUri);

            startDelegate.Start("Download validation file");

            await downloadFromUriAsyncDelegate.DownloadFromUriAsync(
                validationSourceUri,
                validationDirectoryDelegate.GetDirectory(string.Empty));

            completeDelegate.Complete();
        }
    }
}