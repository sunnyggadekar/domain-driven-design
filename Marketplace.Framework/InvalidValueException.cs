using System;

namespace Marketplace.Framework
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(Type type, string message):
            base($"value of {type.Name} {message}")
        {

        }
    }
}
