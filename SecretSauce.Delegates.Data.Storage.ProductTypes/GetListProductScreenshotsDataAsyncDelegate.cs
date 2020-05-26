using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetListProductScreenshotsDataAsyncDelegate : GetJSONDataAsyncDelegate<List<ProductScreenshots>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListProductScreenshotsDelegate))]
        public GetListProductScreenshotsDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<ProductScreenshots>> convertJSONToListProductScreenshotsDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListProductScreenshotsDelegate)
        {
            // ...
        }
    }
}