namespace SecretSauce.Delegates.Conversions.Interfaces
{
    public interface IConvertDelegate<in From, out To>
    {
        To Convert(From data);
    }
}