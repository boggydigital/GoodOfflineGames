﻿using Interfaces.Controllers.Data;
using Interfaces.Delegates.Activities;
using Models.ProductTypes;
using GOG.Interfaces.Delegates.DownloadProductFile;
using Attributes;
using GOG.Models;

namespace GOG.Delegates.Respond.Download.ProductTypes
{
    [RespondsToRequests(Method = "download", Collection = "productfiles")]
    public class RespondToDownloadProductFilesRequestDelegate : RespondToDownloadRequestDelegate<ProductFile>
    {
        [Dependencies(
            "Controllers.Data.ProductTypes.ProductDownloadsDataController,Controllers",
            "GOG.Delegates.DownloadProductFile.DownloadManualUrlFileAsyncDelegate,GOG.Delegates",
            "Delegates.Activities.StartDelegate,Delegates",
            "Delegates.Activities.SetProgressDelegate,Delegates",
            "Delegates.Activities.CompleteDelegate,Delegates")]
        public RespondToDownloadProductFilesRequestDelegate(
            IDataController<ProductDownloads> productDownloadsDataController,
            IDownloadProductFileAsyncDelegate downloadProductFileAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                productDownloadsDataController,
                downloadProductFileAsyncDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}