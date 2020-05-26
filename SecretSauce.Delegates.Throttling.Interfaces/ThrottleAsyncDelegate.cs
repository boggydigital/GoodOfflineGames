using System.Threading.Tasks;

namespace SecretSauce.Delegates.Throttling.Interfaces
{
    public interface IThrottleAsyncDelegate<Type>
    {
        Task ThrottleAsync(Type data);
    }
}