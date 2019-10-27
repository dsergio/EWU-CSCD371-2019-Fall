using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public class MockConfig : IConfig
    {
        public Dictionary<string, string> ConfigList { get; private set; }

        public MockConfig()
        {
            ConfigList = new Dictionary<string, string>();
        }

        private bool IsInputValid(string? str)
        {
            return !(string.IsNullOrEmpty(str) || (new Regex("[\\s=]+").Matches(str).Count > 0));
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if (IsInputValid(name))
            {
                bool success = ConfigList.TryGetValue(name, out string? val);
                value = val;
                return success;
            }
            value = null;
            return false;
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (IsInputValid(name) && IsInputValid(value) && !(value is null))
            {
                ConfigList.Add(name, value);
                return true;
            }
            return false;
        }
    }
}
