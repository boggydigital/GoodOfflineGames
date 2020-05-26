namespace SecretSauce.Delegates.Values.Interfaces
{
    public interface IGetInstanceDelegate<out Type>
    {
        Type GetInstance();
    }
}