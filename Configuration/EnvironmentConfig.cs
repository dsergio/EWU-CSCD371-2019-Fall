using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public class EnvironmentConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            value = Environment.GetEnvironmentVariable(name);
            return !(value is null);
        }

        private bool IsInputValid(string? str)
        {
            return !(string.IsNullOrEmpty(str) || (new Regex("[\\s=]+").Matches(str).Count > 0));
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (IsInputValid(name) && IsInputValid(value))
            {
                Environment.SetEnvironmentVariable(name, value);
                return true;
            }
            if (!IsInputValid(name))
            {
                throw new ArgumentException(name);
            }
            if (!IsInputValid(value))
            {
                throw new ArgumentException(name);
            }
            return false;
        }

        

        //public static void PrintAllConfigValues()
        //{
        //    foreach (DictionaryEntry v in Environment.GetEnvironmentVariables())
        //    {
        //        Console.WriteLine(v.Key + "=" + v.Value);
        //    }
        //}
    }
}
