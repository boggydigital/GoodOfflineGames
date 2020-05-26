using System.Threading.Tasks;

namespace GOG.Delegates.Authorization.Interfaces
{
    public interface IAuthorizeAsyncDelegate
    {
        Task AuthorizeAsync(string username, string password);
    }
}