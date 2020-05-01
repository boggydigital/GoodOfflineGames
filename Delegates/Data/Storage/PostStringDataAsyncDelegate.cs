using System.IO;
using System.Threading.Tasks;
using Attributes;
using Interfaces.Delegates.Convert;
using Interfaces.Delegates.Data;

namespace Delegates.Data.Storage
{
    public class PostStringDataAsyncDelegate : IPostDataAsyncDelegate<string>
    {
        private readonly IConvertDelegate<string, Stream> convertUriToWritableStream;

        [Dependencies(
            typeof(Delegates.Convert.Streams.ConvertUriToWritableStreamDelegate))]
        public PostStringDataAsyncDelegate(
            IConvertDelegate<string, Stream> convertUriToWritableStream)
        {
            this.convertUriToWritableStream = convertUriToWritableStream;
        }

        public async Task<string> PostDataAsync(string data, string uri = null)
        {
            using (var stream = convertUriToWritableStream.Convert(uri))
            using (var writer = new StreamWriter(stream))
            {
                await writer.WriteLineAsync(data);
            }

            return uri;
        }
    }
}