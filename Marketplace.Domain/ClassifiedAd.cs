using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public Guid Id { get; }
        private readonly UserId _ownerId;

        public ClassifiedAd(Guid id, UserId ownerId) 
        {
            if (id == default)
                throw new ArgumentException("Identity must be specified",nameof(id));
            Id = id;

            _ownerId = ownerId;
        }

        public void SetTitle(string title) => _tittle = title;
        public void UpdateText(string text) => _text = text;
        public void UpdatePrice(decimal price) => _price = price;

        private string _tittle;
        private string _text;
        private decimal _price;

    }
}
