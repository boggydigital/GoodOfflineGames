using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IDeleteAsyncDelegate<in Type>
    {
        Task DeleteAsync(Type data);
    }
}