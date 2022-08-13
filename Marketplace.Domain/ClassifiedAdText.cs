using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class ClassifiedAdText : Value<ClassifiedAdText>
    {
        public static ClassifiedAdText FromString(string adText) => new(adText);

        public string Value { get; }

        internal ClassifiedAdText(string value) => Value = value;

        public static implicit operator string(ClassifiedAdText text) => text.Value;

    }
}