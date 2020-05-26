using SecretSauce.Delegates.Data.Interfaces;

namespace SecretSauce.Delegates.Data.Console
{
    public class GetLineDataDelegate : IGetDataDelegate<string>
    {
        public string GetData(string message = null)
        {
            System.Console.WriteLine(message);
            return System.Console.ReadLine();
        }
    }
}