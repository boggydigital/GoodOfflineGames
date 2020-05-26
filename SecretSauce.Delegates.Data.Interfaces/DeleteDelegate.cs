namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IDeleteDelegate<in T>
    {
        void Delete(T uri);
    }
}