
using System;

namespace Mailbox
{
    [Flags]
    public enum Size
    {
        Medium = 0b0000,
        Small = 0b0001,
        Large = 0b0010,
        Premium = 0b0100
    }
}
