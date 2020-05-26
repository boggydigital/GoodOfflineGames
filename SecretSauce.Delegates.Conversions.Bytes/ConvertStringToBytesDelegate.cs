using System.Text;
using SecretSauce.Delegates.Conversions.Interfaces;

namespace SecretSauce.Delegates.Conversions.Bytes
{
    public class ConvertStringToBytesDelegate : IConvertDelegate<string, byte[]>
    {
        public byte[] Convert(string data)
        {
            if (string.IsNullOrEmpty(data))
                return new byte[0];

            return Encoding.UTF8.GetBytes(data);
        }
    }
}