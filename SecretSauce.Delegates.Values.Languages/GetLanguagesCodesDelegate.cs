using System.Collections.Generic;
using Models.Languages;

namespace SecretSauce.Delegates.Values.Languages
{
    public class GetLanguageCodesDelegate : GetConstValueDelegate<Dictionary<string, string>>
    {
        public GetLanguageCodesDelegate() :
            base(Codes.LanguageCodes)
        {
            // ...
        }
    }
}