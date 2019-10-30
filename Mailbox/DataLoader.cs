using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader
    {
        public Stream MyStream { get; set; }

        public DataLoader(Stream source)
        {
            MyStream = source ?? throw new System.ArgumentNullException(nameof(source));
        }

        public List<Mailbox> Load()
        {
            var reader = new StreamReader(MyStream);

            string line = reader.ReadToEnd();
            List<Mailbox> mailboxes = JsonConvert.DeserializeObject<List<Mailbox>>(line);

            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            string json = JsonConvert.SerializeObject(mailboxes, Formatting.Indented);
        }
    }
}
