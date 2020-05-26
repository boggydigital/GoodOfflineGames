using Models.Patterns;

namespace SecretSauce.Delegates.Itemizations.HtmlAttributes
{
    public class ItemizeLoginTokenAttributeValuesDelegate : ItemizeAttributeValuesDelegate
    {
        public ItemizeLoginTokenAttributeValuesDelegate() :
            base(AttributeValuesPatterns.LoginToken)
        {
            // ...
        }
    }
}