using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : Value<ClassifiedAdId>
    {
        private readonly string _value;

        public ClassifiedAdText(string value)
        {
            _value = value;
        }
    }
}