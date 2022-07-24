﻿using Marketplace.Framework;
using System;

namespace Marketplace.Domain
{
    public class UserId : Value<UserId>
    {
        private readonly Guid _value;
        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");

            _value = value;
        }

        public static implicit operator Guid(UserId self)
        {
            return self._value;
        }
    }
}
