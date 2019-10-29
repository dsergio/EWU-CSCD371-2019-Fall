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
            

            //environmentConfig.GetConfigValue("COMPUTERNAME", out string str);
            //Console.WriteLine(str);

            //environmentConfig.SetConfigValue("somename", "someval");
            //environmentConfig.GetConfigValue("somename", out string? str);
            //Console.WriteLine("str: " + str);

            //IConfig fileConfig = new FileConfig();
            //fileConfig.SetConfigValue("name", "myval");
        }
    }
}
