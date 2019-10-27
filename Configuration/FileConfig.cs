using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        public bool GetConfigValue(string name, out string? value)
        {
            string filePath = Path.GetFullPath("config.settings");
            if (!File.Exists(filePath))
            {
                value = null;
                return false;
            }
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (name == line.Split("=")[0])
                {
                    value = line.Split("=")[1];
                    return true;
                }
            }
            value = null;
            return false;
        }

        private bool IsInputValid(string? str)
        {
            return !(string.IsNullOrEmpty(str) || (new Regex("[\\s=]+").Matches(str).Count > 0));
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!IsInputValid(name))
            {
                throw new ArgumentException(name);
            }
            if (!IsInputValid(value))
            {
                throw new ArgumentException(name);
            }

            string filePath = Path.GetFullPath("config.settings");
            Console.WriteLine("filePath: " + filePath);
            File.AppendAllText(filePath, $"{name}={value}" + Environment.NewLine);
            return true;
        }


        public static void DeleteConfigFile()
        {
            string filePath = Path.GetFullPath("config.settings");
            File.Delete(filePath);
        }
    }
}
