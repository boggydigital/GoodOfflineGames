using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IPostDataAsyncDelegate<in T>
    {
        Task<string> PostDataAsync(T data, string uri = null);
    }
}