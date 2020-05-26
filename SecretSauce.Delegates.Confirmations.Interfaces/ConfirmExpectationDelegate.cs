namespace SecretSauce.Delegates.Confirmations.Interfaces
{
    public interface IConfirmExpectationDelegate<in DataType, in ExpectationType>
    {
        bool Confirm(DataType data, ExpectationType expectation);
    }
}