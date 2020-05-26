using System.Net.Http;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Conversions.Network;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Network;

namespace GOG.Delegates.Data.Network
{
    public class GetUriDataPolitelyAsyncDelegate :
        GetUriDataAsyncDelegate
    {
        [Dependencies(
            typeof(ConvertHttpRequestMessageToHttpResponseMethodPolitelyAsyncDelegate))]
        public GetUriDataPolitelyAsyncDelegate(
            IConvertAsyncDelegate<HttpRequestMessage, Task<HttpResponseMessage>> convertRequestToResponseAsyncDelegate)
            :
            base(convertRequestToResponseAsyncDelegate)
        {
            // ...
        }
    }
}