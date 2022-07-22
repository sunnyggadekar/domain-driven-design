namespace Marketplace.Domain
{
    public class ClassifiedAd
    {
        public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
        {
            Id = id;
            OwnerId = ownerId;
            State = ClassifiedAdState.InActive;
        }

        public ClassifiedAdId Id { get; }
        public UserId OwnerId { get; }
        public ClassifiedAdTitle Title { get; private set; }
        public ClassifiedAdText Text { get; private set; }
        public Price Price { get; private set; }
        public ClassifiedAdState State { get; private set; }
        public UserId ApprovedBy { get; private set; }

        public enum ClassifiedAdState
        {
            PendingReview,
            Active,
            InActive,
            MarkedAsSold
        }

        public void SetTitle(ClassifiedAdTitle title) => Title = title;
        public void UpdateText(ClassifiedAdText text) => Text = text;
        public void UpdatePrice(Price price) => Price = price;

        public void RequestToPublish()
        {
            if (Title == null)
                throw new InvalidEntityStateException(this, "title cannot be empty");

            if (Text == null)
                throw new InvalidEntityStateException(this, "text cannot be empty");

            if (Price?.Amount == 0)
                throw new InvalidEntityStateException(this, "price cannot be zero");
        }


    }
}
