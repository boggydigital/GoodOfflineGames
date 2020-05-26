using Attributes;
using GOG.Delegates.Conversions.JSON;
using GOG.Delegates.Data.Network;
using GOG.Models;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace GOG.Delegates.Data.Models.ProductTypes
{
    public class GetDeserializedApiProductAsyncDelegate : GetDeserializedProductCoreAsyncDelegate<ApiProduct>
    {
        [Dependencies(
            typeof(GetUriDataPolitelyAsyncDelegate),
            typeof(ConvertJSONToApiProductDelegate))]
        public GetDeserializedApiProductAsyncDelegate(
            IGetDataAsyncDelegate<string, string> getUriDataAsyncDelegate,
            IConvertDelegate<string, ApiProduct> convertJSONToApiProductDelegate) :
            base(
                getUriDataAsyncDelegate,
                convertJSONToApiProductDelegate)
        {
            // ...
        }
    }
}