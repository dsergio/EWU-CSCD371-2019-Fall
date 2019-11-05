using System;

namespace Mailbox
{
    public class Mailbox
    {
        public Sizes MailboxSizes { get; set; }
        public (int, int) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Sizes sizes, (int, int) location, Person owner)
        {
            if (sizes == Sizes.Premium 
                | sizes == (Sizes.Small | Sizes.Medium)
                | sizes == (Sizes.Small | Sizes.Large)
                | sizes == (Sizes.Medium | Sizes.Large)
                )
            {
                throw new ArgumentException("invalid size", nameof(sizes));
            }
            MailboxSizes = sizes;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"{MailboxSizes} {Location} {Owner}";
        }
    }
}
