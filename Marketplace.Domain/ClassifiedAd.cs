using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAdId Id { get; }
        private readonly UserId _ownerId;

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId) 
        {
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
