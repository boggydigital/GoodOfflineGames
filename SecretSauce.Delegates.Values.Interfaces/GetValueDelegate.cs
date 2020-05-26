namespace SecretSauce.Delegates.Values.Interfaces
{
    public interface IGetValueDelegate<out OutputType, in InputType>
    {
        OutputType GetValue(InputType input);
    }
}