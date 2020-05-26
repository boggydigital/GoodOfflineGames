using System.Threading.Tasks;

namespace SecretSauce.Delegates.Confirmations.Interfaces
{
    public interface IConfirmExpectationAsyncDelegate<in DataType, in ExpectationType>
    {
        Task<bool> ConfirmAsync(DataType data, ExpectationType expectation);
    }
}