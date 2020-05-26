using System;
using System.Net.Http;
using System.Threading.Tasks;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Network;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Network
{
    public class GetUriDataToDestinationAsyncDelegate : IGetDataToDestinationAsyncDelegate<string, string>
    {
        private readonly IConvertAsyncDelegate<HttpRequestMessage, Task<HttpResponseMessage>>
            convertRequestToResponseAsyncDelegate;

        private readonly IGetDataToDestinationAsyncDelegate<HttpResponseMessage, string>
            getHttpResponseMessageToDestinationAsyncDelegate;

        [Dependencies(
            typeof(ConvertHttpRequestMessageToHttpResponseMessageAsyncDelegate),
            typeof(GetHttpResponseMessageToDestinationAsyncDelegate))]
        public GetUriDataToDestinationAsyncDelegate(
            IConvertAsyncDelegate<HttpRequestMessage, Task<HttpResponseMessage>>
                convertRequestToResponseAsyncDelegate,
            IGetDataToDestinationAsyncDelegate<HttpResponseMessage, string>
                getHttpResponseMessageToDestinationAsyncDelegate)
        {
            this.convertRequestToResponseAsyncDelegate = convertRequestToResponseAsyncDelegate;
            this.getHttpResponseMessageToDestinationAsyncDelegate = getHttpResponseMessageToDestinationAsyncDelegate;
        }

        public async Task GetDataToDestinationAsyncDelegate(string sourceUri, string destination)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, sourceUri);
                using var response = await convertRequestToResponseAsyncDelegate.ConvertAsync(request);
                await getHttpResponseMessageToDestinationAsyncDelegate.GetDataToDestinationAsyncDelegate(
                    response,
                    destination);
            }
            catch (Exception ex)
            {
                // TODO: Replace statusController warnings
                // await statusController.WarnAsync(downloadEntryTask, $"{sourceUri}: {ex.Message}");
            }
        }
    }
}