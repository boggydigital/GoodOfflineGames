using Models.Patterns;

namespace SecretSauce.Delegates.Itemizations.HtmlAttributes
{
    public class ItemizeLoginIdAttributeValuesDelegate : ItemizeAttributeValuesDelegate
    {
        public ItemizeLoginIdAttributeValuesDelegate() :
            base(AttributeValuesPatterns.LoginId)
        {
            // ...
        }
    }
}