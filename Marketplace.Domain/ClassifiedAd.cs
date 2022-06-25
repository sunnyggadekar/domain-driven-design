using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        //only one public field.
        public Guid Id { get; private set; }

        //while creating identity Id must be supplied.
        public ClassifiedAd(Guid id, Guid ownerId) 
        {
            if (id == default)
                throw new ArgumentException("Identity must be specified",nameof(id));
            Id = id;

            if (ownerId == default)
                throw new ArgumentException("Owner id must be specified", nameof(ownerId));
            _ownerId = ownerId;
        }

        //Adding Behavior.
        public void SetTitle(string title) => _tittle = title;

        public void UpdateText(string text) => _text = text;

        public void UpdatePrice(decimal price) => _price = price;

        //rest are all priavte properties to take advantage of encapsulation.
        private Guid _ownerId;
        private string _tittle;
        private string _text;
        private decimal _price;

    }
}
