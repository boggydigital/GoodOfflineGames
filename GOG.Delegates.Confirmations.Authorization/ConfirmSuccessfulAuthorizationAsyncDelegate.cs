using SecretSauce.Delegates.Confirmations.Interfaces;

namespace GOG.Delegates.Confirmations.Authorization
{
    // TODO: Needs a better way to confirm following gogData deprecation
    public class ConfirmSuccessfulAuthorizationDelegate : IConfirmDelegate<string>
    {
        public bool Confirm(string data)
        {
            return false;
        }
    }
}