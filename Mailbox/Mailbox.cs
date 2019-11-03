namespace Mailbox
{
    public class Mailbox
    {
        public Sizes MailboxSize { get; set; }
        public (int, int) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Sizes size, (int, int) location, Person owner)
        {
            MailboxSize = size;
            Location = location;
            Owner = owner;
        }

        public override string ToString()
        {
            return $"{MailboxSize} {Location} {Owner}";
        }
    }
}
