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
    [ApiEndpoint(Method = "cleanup", Collection = "files")]
    public class CleanupFilesAsyncDelegate : CleanupAsyncDelegate<ProductFile>
    {
        [Dependencies(
            typeof(ItemizeAllGameDetailsDirectoriesAsyncDelegate),
            typeof(ItemizeAllProductFilesDirectoriesAsyncDelegate),
            typeof(ItemizeDirectoryFilesDelegate),
            typeof(ConvertFilePathToValidationFilePathDelegate),
            typeof(DeleteToRecycleDelegate),
            typeof(StartDelegate),
            typeof(SetProgressDelegate),
            typeof(CompleteDelegate))]
        public CleanupFilesAsyncDelegate(
            IItemizeAllAsyncDelegate<string> itemizeAllExpectedProductFilesAsyncDelegate,
            IItemizeAllAsyncDelegate<string> itemizeAllActualProductFilesAsyncDelegate,
            IItemizeDelegate<string, string> itemizeDetailsDelegate,
            IConvertDelegate<string, string> convertFilePathToValidationFilePathDelegate,
            IDeleteDelegate<string> deleteDelegate,
            IStartDelegate startDelegate,
            ISetProgressDelegate setProgressDelegate,
            ICompleteDelegate completeDelegate) :
            base(
                itemizeAllExpectedProductFilesAsyncDelegate,
                itemizeAllActualProductFilesAsyncDelegate,
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