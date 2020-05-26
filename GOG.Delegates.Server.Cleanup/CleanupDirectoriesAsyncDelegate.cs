using Attributes;
using GOG.Delegates.Itemizations;
using GOG.Delegates.Itemizations.ProductTypes;
using Models.ProductTypes;
using SecretSauce.Delegates.Activities;
using SecretSauce.Delegates.Activities.Interfaces;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Uris;
using SecretSauce.Delegates.Data.Interfaces;
using SecretSauce.Delegates.Data.Storage.Recycle;
using SecretSauce.Delegates.Itemizations;
using SecretSauce.Delegates.Itemizations.Interfaces;

namespace GOG.Delegates.Server.Cleanup
{
    [ApiEndpoint(Method = "cleanup", Collection = "directories")]
    public class CleanupDirectoriesAsyncDelegate : CleanupAsyncDelegate<ProductDirectory>
    {
        [Dependencies(
            typeof(ItemizeAllUpdatedGameDetailsManualUrlFilesAsyncDelegate),
            typeof(ItemizeAllUpdatedProductFilesAsyncDelegate),
            typeof(ItemizePassthroughDelegate),
            typeof(ConvertFilePathToValidationFilePathDelegate),
            typeof(DeleteToRecycleDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public CleanupDirectoriesAsyncDelegate(
            IItemizeAllAsyncDelegate<string> itemizeAllExpectedProductDirectoriesAsyncDelegate,
            IItemizeAllAsyncDelegate<string> itemizeAllActualProductDirectoriesAsyncDelegate,
            IItemizeDelegate<string, string> itemizeDetailsDelegate,
            IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate,
            IDeleteDelegate<string> deleteDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllExpectedProductDirectoriesAsyncDelegate,
                itemizeAllActualProductDirectoriesAsyncDelegate,
                itemizeDetailsDelegate,
                convertFilePathToValidationFilePathDelegate,
                deleteDelegate,
                startDelegate,
                setProgressDelegate,
                completeDelegate)
        {
            // ...
        }
    }
}