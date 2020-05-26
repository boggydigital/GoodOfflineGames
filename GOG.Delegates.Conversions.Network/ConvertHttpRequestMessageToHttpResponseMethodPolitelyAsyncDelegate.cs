using System.Net.Http;
using System.Threading.Tasks;
using Attributes;
using GOG.Delegates.Throttling.Network;
using SecretSauce.Delegates.Conversions.Network;
using SecretSauce.Delegates.Throttling.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Network;

namespace GOG.Delegates.Conversions.Network
{
    public class ConvertHttpRequestMessageToHttpResponseMethodPolitelyAsyncDelegate :
        ConvertHttpRequestMessageToHttpResponseMessageAsyncDelegate
    {
        private readonly IThrottleAsyncDelegate<string> throttleUriAsyncDelegate;

        [Dependencies(
            typeof(GetHttpClientInstanceDelegate),
            typeof(ThrottleGOGRequestRateAsyncDelegate))]
        public ConvertHttpRequestMessageToHttpResponseMethodPolitelyAsyncDelegate(
            IGetInstanceDelegate<HttpClient> getHttpClientInstanceDelegate,
            IThrottleAsyncDelegate<string> throttleUriAsyncDelegate) :
            base(getHttpClientInstanceDelegate)
        {
            this.throttleUriAsyncDelegate = throttleUriAsyncDelegate;
        }

        public override async Task<HttpResponseMessage> ConvertAsync(HttpRequestMessage request)
        {
            await throttleUriAsyncDelegate.ThrottleAsync(request.RequestUri.AbsoluteUri);

            return await base.ConvertAsync(request);
        }
    }
}