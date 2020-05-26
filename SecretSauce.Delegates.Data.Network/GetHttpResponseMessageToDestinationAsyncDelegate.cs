using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Attributes;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Conversions.Streams;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Network
{
    public class GetHttpResponseMessageToDestinationAsyncDelegate :
        IGetDataToDestinationAsyncDelegate<HttpResponseMessage, string>
    {
        private readonly IConvertDelegate<string, Stream> convertUriToWritableRStream;

        [Dependencies(
            typeof(ConvertUriToWritableStreamDelegate))]
        public GetHttpResponseMessageToDestinationAsyncDelegate(
            IConvertDelegate<string, Stream> convertUriToWritableRStream)
        {
            this.convertUriToWritableRStream = convertUriToWritableRStream;
        }

        public async Task GetDataToDestinationAsyncDelegate(HttpResponseMessage response, string destination)
        {
            response.EnsureSuccessStatusCode();

            var filename = response.RequestMessage.RequestUri.Segments.Last();
            var fullPath = Path.Combine(destination, filename);

            var bufferSize = 1024 * 1024; // 1M
            var buffer = new byte[bufferSize];
            var bytesRead = 0;
            long totalBytesRead = 0;

            // don't redownload file with the same name and size
            if (File.Exists(fullPath) &&
                new FileInfo(fullPath).Length == response.Content.Headers.ContentLength)
                // await statusController.InformAsync(
                //     status, 
                //     $"File {fullPath} already exists and matches response size, will not be redownloading");
                return;

            using (var writeableStream = convertUriToWritableRStream.Convert(fullPath))
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                while ((bytesRead = await responseStream.ReadAsync(buffer, 0, bufferSize)) > 0)
                {
                    totalBytesRead += bytesRead;
                    var contentLength = response.Content.Headers.ContentLength != null
                        ? (long) response.Content.Headers.ContentLength
                        : totalBytesRead;
                    await writeableStream.WriteAsync(buffer, 0, bytesRead);
                }
            }
        }
    }
}