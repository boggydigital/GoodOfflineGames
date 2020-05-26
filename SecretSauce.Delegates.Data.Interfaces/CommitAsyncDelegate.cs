using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface ICommitAsyncDelegate
    {
        Task CommitAsync();
    }
}