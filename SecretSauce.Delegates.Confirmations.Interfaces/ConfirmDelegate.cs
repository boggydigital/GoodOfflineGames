namespace SecretSauce.Delegates.Confirmations.Interfaces
{
    public interface IConfirmDelegate<in T>
    {
        bool Confirm(T data);
    }
}