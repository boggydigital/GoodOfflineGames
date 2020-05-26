using SecretSauce.Delegates.Values.Interfaces;

namespace SecretSauce.Delegates.Values
{
    public abstract class GetConstValueDelegate<OutputType> : IGetValueDelegate<OutputType, string>
    {
        private readonly OutputType constValue;

        public GetConstValueDelegate(OutputType constValue)
        {
            this.constValue = constValue;
        }

        public OutputType GetValue(string input)
        {
            return constValue;
        }
    }
}