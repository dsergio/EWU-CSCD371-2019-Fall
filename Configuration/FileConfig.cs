using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Configuration
{
    public class FileConfig : IConfig, IConfigGroup
    {
        private string FilePath { get; set; }

        public FileConfig()
        {
            FilePath = Path.GetFullPath("config.settings");
        }

        public bool GetConfigValue(string name, out string? value)
        {
            if (!File.Exists(FilePath))
            {
                value = null;
                return false;
            }
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                if (line.Split("=").Length == 2 && name == line.Split("=")[0])
                {
                    value = line.Split("=")[1];
                    return true;
                }
            }
            value = null;
            return false;
        }

        // MMM Comment: Didn't you have the same in EnvironmetConfig?  Why not refactor?
        private bool IsInputValid(string? str)
        {
            return !(string.IsNullOrEmpty(str) || (new Regex("[\\s=]+").Matches(str).Count > 0));
        }

        public bool SetConfigValue(string name, string? value)
        {
            if (!IsInputValid(name))
            {
                return false;
            }
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            if (GetConfigValue(name, out _))
            {
                string[] lines = File.ReadAllLines(FilePath);
                Dictionary<string, string?> newConfig = new Dictionary<string, string?>();
                foreach (string line in lines)
                {
                    // MMM Comment: Great to see the validation that split works.
                    if (line.Split("=").Length == 2 && name == line.Split("=")[0])
                    {
                        newConfig.Add(name, value);
                    } 
                    else
                    {
                        newConfig.Add(line.Split("=")[0], line.Split("=")[1]);
                    }
                }
                DeleteConfigFile();
                foreach (KeyValuePair<string, string?> v in newConfig)
                {
                    File.AppendAllText(FilePath, $"{v.Key}={v.Value}" + Environment.NewLine);
                }
            }
            else
            {
                File.AppendAllText(FilePath, $"{name}={value}" + Environment.NewLine);
            }
            
            return true;
        }

        // MMM Comment: Not sure this was worth refactoring as File.Delete seems pretty clear.
        public void DeleteConfigFile()
        {
            File.Delete(FilePath);
        }

        public bool GetConfigValues(string filter, out Dictionary<string, string?> results)
        {
            // MMM Comment: Mulitple constructor calls here seems like it could be simplified
            // by assigning results before the if.
            if (!File.Exists(FilePath))
            {
                results = new Dictionary<string, string?>();
                return false;
            }
            results = new Dictionary<string, string?>();

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                // MMM Comment: Regex again...  If you go this far, you may as well use
                // named groups. :)
                if (line.Split("=").Length == 2 && (new Regex(filter).Matches(line.Split("=")[0]).Count > 0))
                {
                    results.Add(line.Split("=")[0], line.Split("=")[1]);
                }
            }

            // MMM Comment: Just return (results.Count != 0)
            if (results.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
