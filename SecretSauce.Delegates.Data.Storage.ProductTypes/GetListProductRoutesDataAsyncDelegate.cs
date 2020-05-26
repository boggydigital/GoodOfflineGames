using System.Collections.Generic;
using Attributes;
using Models.ProductTypes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.JSON.ProductTypes;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage.ProductTypes
{
    public class GetListProductRoutesDataAsyncDelegate : GetJSONDataAsyncDelegate<List<ProductRoutes>>
    {
        [Dependencies(
            typeof(GetStringDataAsyncDelegate),
            typeof(ConvertJSONToListProductRoutesDelegate))]
        public GetListProductRoutesDataAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getStringDataAsyncDelegate,
            IConvertDelegate<string, List<ProductRoutes>> convertJSONToListProductRoutesDelegate) :
            base(
                getStringDataAsyncDelegate,
                convertJSONToListProductRoutesDelegate)
        {
            // ...
        }
    }
}