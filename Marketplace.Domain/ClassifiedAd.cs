using Marketplace.Framework;

namespace Marketplace.Domain
{
    public class ClassifiedAd : Entity
    {
        public ClassifiedAdId Id { get; }
        public UserId OwnerId { get; }
        public ClassifiedAdTitle Title { get; private set; }
        public ClassifiedAdText Text { get; private set; }
        public Price Price { get; private set; }
        public ClassifiedAdState State { get; private set; }
        public UserId ApprovedBy { get; private set; }

        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;

            EnsureValidState();

            Raise(new Events.ClassifiedAdCreated
            {
                Id = id,
                OwnerId = ownerId
            });

            State = ClassifiedAdState.InActive;
        }

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            InActive,
            MarkedAsSold
        }

        public void SetTitle(ClassifiedAdTitle title)
        {
            Title = title;
            Raise(new Events.ClassifiedAdTitleChanged
            {
                Id = Id,
                Tittle = title
            });
            EnsureValidState();
        }

        public void UpdateText(ClassifiedAdText text)
        {
            Text = text;
            Raise(new Events.ClassifiedAdTextUpdated
            {
                Id = Id,
                AdText = text
            });
            EnsureValidState();
        }

        public void UpdatePrice(Price price)
        {
            Price = price;
            Raise(new Events.ClassifiedAdPriceUpdated
            {
                Id = Id,
                Price = price
            });
            EnsureValidState();
        }

        public void RequestToPublish()
        {
            State = ClassifiedAdState.PendingReview;
            Raise(new Events.ClassifiedAdSentForReview
            {
                Id = Id
            });
            EnsureValidState();
        }

        void EnsureValidState()
        {
            var valid =
                Id != null &&
                OwnerId != null &&
                (State switch
                {
                    ClassifiedAdState.PendingReview => Title != null && Text != null && Price?.Amount > 0,
                    ClassifiedAdState.Active => Title != null && Text != null && Price?.Amount > 0 && ApprovedBy != null,
                    _ => true
                });

            if (!valid)
                throw new InvalidEntityStateException(this, "Post-checks failed in state");
        }

    }
}
