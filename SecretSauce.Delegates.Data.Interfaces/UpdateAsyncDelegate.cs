using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IUpdateAsyncDelegate<in Type>
    {
        Task UpdateAsync(Type data);
    }
}