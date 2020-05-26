namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IGetDataDelegate<out T>
    {
        T GetData(string uri = null);
    }
}