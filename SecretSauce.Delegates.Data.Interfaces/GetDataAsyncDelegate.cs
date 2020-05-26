using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IGetDataAsyncDelegate<Type, in UriType>
    {
        Task<Type> GetDataAsync(UriType uri);
    }
}