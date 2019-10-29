using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    /// <summary>
    /// Extra Credit
    /// Create an IConfigGroup that returns a set of setting based on wildcard filters (rather than just a single setting)
    /// 
    /// </summary>
    public interface IConfigGroup
    {
        bool GetConfigValues(string filter, out Dictionary<string, string?> results);

    }
}
