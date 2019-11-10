using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public class EnvironmentConfig : IConfig, IConfigGroup
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        // MMM Comment: Nice refactoring.
        private bool IsInputValid(string? str)
        {
            // MMM Comment: Nice job with the regex.
            return !(string.IsNullOrEmpty(str) || (new Regex("[\\s=]+").Matches(str).Count > 0));
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (IsInputValid(name))
            {
                try
                {
                    // MMM Comment: Why not use IsInputValid on value?
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException(value);
                    }
                    Environment.SetEnvironmentVariable(name, value);
                    return true;
                } 
                catch (ArgumentException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // MMM Comment: Nice given we haven't covered creating iterators yet. :)
        public bool GetConfigValues(string filter, out Dictionary<string, string?> results)
        {
            results = new Dictionary<string, string?>();
            foreach (DictionaryEntry v in Environment.GetEnvironmentVariables())
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
