using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        public static ClassifiedAdText FromString(string adText) => new(adText);

        private readonly string _value;

        private ClassifiedAdText(string value)
        {
            if (value == string.Empty)
                throw new ArgumentOutOfRangeException(nameof(value), "Ad text cannot be empty");
            _value = value;
        }

    }
}