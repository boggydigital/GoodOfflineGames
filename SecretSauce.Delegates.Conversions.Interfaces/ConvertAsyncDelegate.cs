namespace SecretSauce.Delegates.Conversions.Interfaces
{
    public interface IConvertAsyncDelegate<in From, out To>
    {
        public To ConvertAsync(From data);
    }
}