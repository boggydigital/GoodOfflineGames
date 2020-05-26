using System.Collections.Generic;
using System.Linq;
using Attributes;
using SecretSauce.Delegates.Confirmations.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Languages;

namespace SecretSauce.Delegates.Confirmations.Languages
{
    public class ConfirmLanguageCodeDelegate : IConfirmDelegate<string>
    {
        private readonly IGetValueDelegate<Dictionary<string, string>, string> getLanguageCodesDelegate;

        [Dependencies(
            typeof(GetLanguageCodesDelegate))]
        public ConfirmLanguageCodeDelegate(
            IGetValueDelegate<Dictionary<string, string>, string> getLanguageCodesDelegate)
        {
            this.getLanguageCodesDelegate = getLanguageCodesDelegate;
        }

        public bool Confirm(string code)
        {
            var languageCodes = getLanguageCodesDelegate.GetValue(string.Empty);
            return languageCodes.Keys.Contains(code);
        }
    }
}