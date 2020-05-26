using System.IO;
using System.Threading.Tasks;
using ProtoBuf;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Storage
{
    public abstract class GetProtoBufDataAsyncDelegate<T> : IGetDataAsyncDelegate<T, string>
    {
        private readonly IConvertDelegate<string, Stream> convertUriToReadableStreamDelegate;

        public GetProtoBufDataAsyncDelegate(
            IConvertDelegate<string, Stream> convertUriToReadableStreamDelegate)
        {
            this.convertUriToReadableStreamDelegate = convertUriToReadableStreamDelegate;
        }

        public async Task<T> GetDataAsync(string uri = null)
        {
            return await Task.Run(() =>
            {
                var data = default(T);

                if (File.Exists(uri))
                    using (var readableStream = convertUriToReadableStreamDelegate.Convert(uri))
                    {
                        data = Serializer.Deserialize<T>(readableStream);
                    }

                return data;
            });
        }
    }
}