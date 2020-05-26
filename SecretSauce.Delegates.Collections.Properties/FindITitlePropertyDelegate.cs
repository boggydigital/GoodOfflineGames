using Attributes;
using Interfaces.Models.Properties;
using SecretSauce.Delegates.Collections.Interfaces;

namespace SecretSauce.Delegates.Collections.Properties
{
    public class FindITitlePropertyDelegate : FindDelegate<ITitleProperty>
    {
        [Dependencies(
            typeof(FindAllITitlePropertyDelegate))]
        public FindITitlePropertyDelegate(
            IFindAllDelegate<ITitleProperty> findAllITitlePropertyDelegate) :
            base(findAllITitlePropertyDelegate)
        {
            // ...
        }
    }
}