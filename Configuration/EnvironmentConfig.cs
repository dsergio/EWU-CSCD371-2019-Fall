using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        public bool SetConfigValue(string name, string? value)
        {
            throw new NotImplementedException();
        }
    }
}
