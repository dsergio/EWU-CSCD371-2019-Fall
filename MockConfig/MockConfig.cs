using Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MockConfiguration
{
    public class MockConfig : IConfig, IConfigGroup
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
            if (IsInputValid(name) && !string.IsNullOrEmpty(value) && ConfigList.ContainsKey(name))
            {
                ConfigList.Remove(name);
                ConfigList.Add(name, value);
                return true;
            }
            else if (IsInputValid(name) && !string.IsNullOrEmpty(value) && !ConfigList.ContainsKey(name))
            {
                ConfigList.Add(name, value);
                return true;
                
            }
            return false;
        }

        public bool GetConfigValues(string filter, out Dictionary<string, string?> results)
        {
            results = new Dictionary<string, string?>();
            foreach (KeyValuePair<string, string> v in ConfigList)
            {
                if (new Regex(filter).Matches(v.Key.ToString()).Count > 0)
                {
                    results.Add(v.Key.ToString(), v.Value?.ToString());
                }
            }

            if (Environment.GetEnvironmentVariables().Count == 0 || results.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
