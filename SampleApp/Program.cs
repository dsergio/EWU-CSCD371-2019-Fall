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

            IConfig environmentConfig = new EnvironmentConfig();

            foreach (string s in hardcodedConfigNames)
            {
                environmentConfig.GetConfigValue(s, out string? val);
                Console.WriteLine(s + "=" + val);
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
