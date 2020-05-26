namespace SecretSauce.Delegates.Data.Interfaces
{
    public interface IMoveDelegate<in T>
    {
        void Move(T from, T to);
    }
}