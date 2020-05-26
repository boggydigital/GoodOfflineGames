using System.Collections.Generic;
using System.Threading.Tasks;
using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Models
{
    public class CountDataAsyncDelegate<Type> : ICountAsyncDelegate
    {
        private readonly IGetDataAsyncDelegate<List<Type>, string> getDataAsyncDelegate;

        public CountDataAsyncDelegate(
            IGetDataAsyncDelegate<List<Type>, string> getDataAsyncDelegate)
        {
            this.getDataAsyncDelegate = getDataAsyncDelegate;
        }

        public async Task<long> CountAsync()
        {
            var data = await getDataAsyncDelegate.GetDataAsync(string.Empty);
            return data.Count;
        }
    }
}