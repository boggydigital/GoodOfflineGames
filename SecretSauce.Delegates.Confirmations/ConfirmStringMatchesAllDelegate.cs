using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Confirmations.Interfaces;

namespace SecretSauce.Delegates.Confirmations
{
    public abstract class ConfirmStringMatchesAllDelegate : IConfirmDelegate<string>
    {
        private readonly IMapDelegate<string> mapDelegate;
        private readonly string[] matches;

        public ConfirmStringMatchesAllDelegate(
            IMapDelegate<string> mapDelegate,
            params string[] matches)
        {
            this.mapDelegate = mapDelegate;
            this.matches = matches;
        }

        public bool Confirm(string entry)
        {
            var matchesAll = true;

            mapDelegate.Map(matches, match => matchesAll &= entry.Contains(match));

            return matchesAll;
        }
    }
}