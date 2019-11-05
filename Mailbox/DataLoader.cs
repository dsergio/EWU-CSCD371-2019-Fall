using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mailbox
{
    public class DataLoader : IDisposable
    {
        public Stream Source { get; set; }

        public DataLoader(Stream source)
        {
            Source = source ?? throw new System.ArgumentNullException(nameof(source));
        }

        public List<Mailbox>? Load()
        {
            Source.Position = 0;


            List<Mailbox> mailboxes = new List<Mailbox>();

            try
            {
                using var reader = new StreamReader(Source, leaveOpen:true);

                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine("line: " + line);
                    Mailbox m = JsonConvert.DeserializeObject<Mailbox>(line);
                    mailboxes.Add(m);
                    line = reader.ReadLine();
                }

            }
            catch (JsonReaderException)
            {
                return null;
            }
            return mailboxes;
        }

        public void Save(List<Mailbox> mailboxes)
        {
            string json = JsonConvert.SerializeObject(mailboxes, Formatting.Indented);

            Source.Position = 0;
            using var writer = new StreamWriter(Source, leaveOpen: true);
            writer.Write(json);

        }




        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Source.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DataLoader()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
