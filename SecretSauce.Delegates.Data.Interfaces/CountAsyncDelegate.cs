using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface ICountAsyncDelegate
    {
        Task<long> CountAsync();
    }
}