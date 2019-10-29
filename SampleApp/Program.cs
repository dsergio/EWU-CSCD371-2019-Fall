using Configuration;
using System;
using System.Collections.Generic;

namespace SampleApp
{
    public class Program
    {
        public static void Main()
        {
            // print out all the configuration settings based on hard coded values for config
            List<string> hardcodedConfigNames = new List<string>
            {
                "PROCESSOR_ARCHITECTURE",
                "USERNAME",
                "HOMEPATH"
            };
            EnvironmentConfig environmentConfig = new EnvironmentConfig();

            foreach (string s in hardcodedConfigNames)
            {
                environmentConfig.GetConfigValue(s, out string? val);
                Console.WriteLine(s + "=" + val);
            }



            // print out all the configuration settings based on hard coded values for config
            FileConfig fileConfig = new FileConfig();
            fileConfig.SetConfigValue("key1", "val1");
            fileConfig.SetConfigValue("key2", "val2");

            fileConfig.GetConfigValue("key1", out string? val2);
            Console.WriteLine("key1=" + val2);

            fileConfig.GetConfigValue("key2", out string? val3);
            Console.WriteLine("key2=" + val3);

            fileConfig.DeleteConfigFile();


            // Extra Credit: 
            // Create an IConfigGroup that returns a set of setting based on wildcard filters (rather than just a single setting)
            //
            _ = environmentConfig.GetConfigValues("USER", out Dictionary<string, string?> results);
            if (results is object)
            {
                foreach (string s in results.Keys)
                {
                    bool valueExists = results.TryGetValue(s, out string? val);
                    if (val is object)
                    {
                        Console.WriteLine(s + "=" + val);
                    }
                }
            }
        }
    }
}
