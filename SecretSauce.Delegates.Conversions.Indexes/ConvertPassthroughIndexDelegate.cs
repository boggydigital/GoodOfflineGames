using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Indexes
{
    public class ConvertPassthroughIndexDelegate : IConvertDelegate<long, long>
    {
        public long Convert(long data)
        {
            return data;
        }
    }
}