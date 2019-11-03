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
            if (location.Item1 < 0 || location.Item1 > 30)
            {
                throw new ArgumentException(nameof(location));
            }
            if (location.Item2 < 0 || location.Item2 > 10)
            {
                throw new ArgumentException(nameof(location));
            }
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"{MailboxSizes} {Location} {Owner}";
        }
    }
}
