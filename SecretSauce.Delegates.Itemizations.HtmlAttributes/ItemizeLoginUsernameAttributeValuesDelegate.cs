using Models.Patterns;

namespace SecretSauce.Delegates.Itemizations.HtmlAttributes
{
    public class ItemizeLoginUsernameAttributeValuesDelegate : ItemizeAttributeValuesDelegate
    {
        public ItemizeLoginUsernameAttributeValuesDelegate() :
            base(AttributeValuesPatterns.LoginUsername)
        {
            // ...
        }
    }
}