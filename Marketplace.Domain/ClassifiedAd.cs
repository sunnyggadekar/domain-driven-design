using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public Guid Id { get; private set; }
        public ClassifiedAd(Guid id)
        {
            if (id == default)
                throw new ArgumentException("Identity must be specified",nameof(id));
            Id = id;
        }

        private Guid _ownerId;
        private string _tittle;
        private string _text;
        private decimal _price;

    }
}
