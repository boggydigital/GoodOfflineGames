using System.Threading.Tasks;

namespace SecretSauce.Delegates.Confirmations.Interfaces
{
    public interface IConfirmAsyncDelegate<in T>
    {
        Task<bool> ConfirmAsync(T data);
    }
}