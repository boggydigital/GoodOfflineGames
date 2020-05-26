using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values
{
    public abstract class GetSingletonInstanceDelegate<T> : IGetInstanceDelegate<T>
        where T : class, new()
    {
        private readonly T value;

        protected GetSingletonInstanceDelegate()
        {
            value = new T();
        }

        public T GetInstance()
        {
            return value;
        }
    }
}