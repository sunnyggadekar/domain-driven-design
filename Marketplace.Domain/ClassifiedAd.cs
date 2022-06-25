using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public Guid Id { get; private set; } //only one public field
        public ClassifiedAd(Guid id) //while creating only entity Id is public available
        {
            if (id == default)
                throw new ArgumentException("Identity must be specified",nameof(id));
            Id = id;
        }

        //rest are all priavte properties to take advantage of encapsulation
        private Guid _ownerId;
        private string _tittle;
        private string _text;
        private decimal _price;

    }
}
