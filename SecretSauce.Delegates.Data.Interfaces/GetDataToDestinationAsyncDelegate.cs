using System.Threading.Tasks;

namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IGetDataToDestinationAsyncDelegate<in SourceType, in DestinationType>
    {
        Task GetDataToDestinationAsyncDelegate(SourceType source, DestinationType destination);
    }
}