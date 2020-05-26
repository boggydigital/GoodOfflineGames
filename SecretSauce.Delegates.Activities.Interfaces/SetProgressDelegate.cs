namespace SecretSauce.Delegates.Activities.Interfaces
{
    public interface ISetProgressDelegate
    {
        void SetProgress(int increment = 1, int target = int.MaxValue);
    }
}