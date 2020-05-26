using Models.Patterns;

namespace SecretSauce.Delegates.Itemizations.HtmlAttributes
{
    public class ItemizeSecondStepAuthenticationTokenAttributeValuesDelegate : ItemizeAttributeValuesDelegate
    {
        public ItemizeSecondStepAuthenticationTokenAttributeValuesDelegate() :
            base(AttributeValuesPatterns.SecondStepAuthenticationToken)
        {
            // ...
        }
    }
}