using Marketplace.Framework;
using System;
using System.Text.RegularExpressions;

namespace Marketplace.Domain
{
    public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
    {
        public static ClassifiedAdTitle FromString(string title) => new(title);

        public static ClassifiedAdTitle FromHtml(string htmlTitle)
        {
            var supportedTagsReplaced = htmlTitle
                .Replace("<i>", "*")
                .Replace("</i>", "*")
                .Replace("<b>", "**")
                .Replace("</b>", "**");
            return new ClassifiedAdTitle(Regex.Replace(
                supportedTagsReplaced, "<.*?>", string.Empty
                ));

        }

        public string Value { get; set; }

        private ClassifiedAdTitle(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Tittle cannot be longer than 100 characters");

            Value = value;
        }

        public static implicit operator string(ClassifiedAdTitle title) => title.Value;
    }
}
