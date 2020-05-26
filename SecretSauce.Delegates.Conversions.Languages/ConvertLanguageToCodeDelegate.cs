using System.Collections.Generic;
using Attributes;
using SecretSauce.Delegates.Collections.Interfaces;
using SecretSauce.Delegates.Collections.System;
using SecretSauce.Delegates.Conversions.Interfaces;
using SecretSauce.Delegates.Values.Interfaces;
using SecretSauce.Delegates.Values.Languages;

namespace SecretSauce.Delegates.Conversions.Languages
{
    public class ConvertLanguageToCodeDelegate : IConvertDelegate<string, string>
    {
        private readonly IFindDelegate<KeyValuePair<string, string>> findLanguageCodeDelegate;
        private readonly IGetValueDelegate<Dictionary<string, string>, string> getLanguageCodesDelegate;

        [Dependencies(
            typeof(GetLanguageCodesDelegate),
            typeof(FindStringKeyStringValuePairDelegate))]
        public ConvertLanguageToCodeDelegate(
            IGetValueDelegate<Dictionary<string, string>, string> getLanguageCodesDelegate,
            IFindDelegate<KeyValuePair<string, string>> findLanguageCodeDelegate)
        {
            this.getLanguageCodesDelegate = getLanguageCodesDelegate;
            this.findLanguageCodeDelegate = findLanguageCodeDelegate;
        }

        public string Convert(string language)
        {
            var languageCodes = getLanguageCodesDelegate.GetValue(string.Empty);
            return findLanguageCodeDelegate.Find(languageCodes, lc => lc.Value == language).Key;
        }
    }
}