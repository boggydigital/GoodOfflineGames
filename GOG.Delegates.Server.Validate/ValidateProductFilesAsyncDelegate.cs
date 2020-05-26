using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Data.Models.ProductTypes;
using GOG.Delegates.Itemizations;
using GOG.Delegates.Itemizations.ProductTypes.GameDetails;
using GOG.Delegates.Server.Interfaces;
using GOG.Models;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Confirmations.Validation;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Models.ProductTypes;
using SecretSauce.Delegates.Itemizations.Interfaces;
using SecretSauce.Delegates.Itemizations.ProductTypes;
using SecretSauce.Delegates.Values.Directories.ProductTypes;
using SecretSauce.Delegates.Values.Filenames;
using SecretSauce.Delegates.Values.Interfaces;

namespace GOG.Delegates.Server.Validate
{
    [ApiEndpoint(Method = "validate", Collection = "productfiles")]
    public class ValidateProductFilesAsyncDelegate : IProcessAsyncDelegate
    {
        private readonly ICompleteDelegate completeDelegate;

        private readonly IConfirmExpectationAsyncDelegate<string, string>
            confirmFileValidationExpectationsAsyncDelegate;

        private readonly IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate;
        private readonly IGetDataAsyncDelegate<GameDetails, long> getGameDetailsByIdAsyncDelegate;
        private readonly IGetValueDelegate<string, string> getProductFileFilenameDelegate;
        private readonly IGetDataAsyncDelegate<string, (long Id, string Source)> getRouteDataAsyncDelegate;
        private readonly IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate;
        private readonly IItemizeAsyncDelegate<GameDetails, string> itemizeGameDetailsManualUrlsAsyncDelegate;
        private readonly IGetValueDelegate<string, string> productFileDirectoryDelegate;
        private readonly ISetProgressDelegate setProgressDelegate;
        private readonly IStartDelegate startDelegate;

        [Dependencies(
            typeof(GetProductFilesDirectoryDelegate),
            typeof(GetUriFilenameDelegate),
            typeof(ConvertFilePathToValidationFilePathDelegate),
            typeof(ConfirmFileValidationExpectationsAsyncDelegate),
            typeof(ItemizeAllUpdatedAsyncDelegate),
            typeof(GetGameDetailsByIdAsyncDelegate),
            typeof(ItemizeGameDetailsManualUrlsAsyncDelegate),
            typeof(GetRouteDataAsyncDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public ValidateProductFilesAsyncDelegate(
            IGetValueDelegate<string, string> productFileDirectoryDelegate,
            IGetValueDelegate<string, string> getProductFileFilenameDelegate,
            IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate,
            IConfirmExpectationAsyncDelegate<string, string> confirmFileValidationExpectationsAsyncDelegate,
            IItemizeAllAsyncDelegate<long> itemizeAllUpdatedAsyncDelegate,
            IGetDataAsyncDelegate<GameDetails, long> getGameDetailsByIdAsyncDelegate,
            IItemizeAsyncDelegate<GameDetails, string> itemizeGameDetailsManualUrlsAsyncDelegate,
            IGetDataAsyncDelegate<string, (long Id, string Source)> getRouteDataAsyncDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate)
        {
            this.productFileDirectoryDelegate = productFileDirectoryDelegate;
            this.getProductFileFilenameDelegate = getProductFileFilenameDelegate;
            this.convertFilePathToValidationFilePathDelegate = convertFilePathToValidationFilePathDelegate;
            this.confirmFileValidationExpectationsAsyncDelegate = confirmFileValidationExpectationsAsyncDelegate;
            this.getGameDetailsByIdAsyncDelegate = getGameDetailsByIdAsyncDelegate;
            this.itemizeGameDetailsManualUrlsAsyncDelegate = itemizeGameDetailsManualUrlsAsyncDelegate;

            this.itemizeAllUpdatedAsyncDelegate = itemizeAllUpdatedAsyncDelegate;
            this.getRouteDataAsyncDelegate = getRouteDataAsyncDelegate;

            this.startDelegate = startDelegate;
            this.setProgressDelegate = setProgressDelegate;
            this.completeDelegate = completeDelegate;
        }

        public async Task ProcessAsync(IDictionary<string, IEnumerable<string>> parameters)
        {
            startDelegate.Start("Validate products");

            // TODO: Should this be itemizeAllUpdatedGameDetails instead?
            await foreach (var id in itemizeAllUpdatedAsyncDelegate.ItemizeAllAsync())
            {
                var gameDetails = await getGameDetailsByIdAsyncDelegate.GetDataAsync(id);

                setProgressDelegate.SetProgress();

                var localFiles = new List<string>();

                startDelegate.Start("Enumerate local product files");
                foreach (var manualUrl in
                    await itemizeGameDetailsManualUrlsAsyncDelegate.ItemizeAsync(gameDetails))
                {
                    var resolvedUri = await getRouteDataAsyncDelegate.GetDataAsync((id, manualUrl));

                    // use directory from source and file from resolved URI
                    var localFile = Path.Combine(
                        productFileDirectoryDelegate.GetValue(manualUrl),
                        getProductFileFilenameDelegate.GetValue(resolvedUri));

                    localFiles.Add(localFile);
                }

                completeDelegate.Complete();


                // check if current validation results allow us to skip validating current product
                // otherwise - validate all the files again

                // ...

                startDelegate.Start("Validate product files");

                foreach (var localFile in localFiles)
                {
                    setProgressDelegate.SetProgress();

                    var validationFile = convertFilePathToValidationFilePathDelegate.Convert(localFile);

                    try
                    {
                        if (!await confirmFileValidationExpectationsAsyncDelegate.ConfirmAsync(
                            localFile,
                            validationFile))
                            throw new InvalidDataException();
                    }
                    catch (Exception ex)
                    {
                        // await statusController.FailAsync(validateProductsStatus,
                        //     $"{localFile}: {ex.Message}");
                    }
                }

                completeDelegate.Complete();
            }

            completeDelegate.Complete();
        }
    }
}