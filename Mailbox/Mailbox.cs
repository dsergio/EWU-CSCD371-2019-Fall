namespace Mailbox
{
    public class Mailbox
    {
        public Size MailboxSize { get; set; }
        public (int, int) Location { get; set; }
        public Person Owner { get; set; }

        public Mailbox(Size size, (int, int) location, Person owner)
        {
            MailboxSize = size;
            Location = location;
            Owner = owner ?? throw new System.ArgumentNullException(nameof(owner));
        }

        public override string ToString()
        {
            return $"{MailboxSize} {Location} {Owner}";
        }
    }
}
