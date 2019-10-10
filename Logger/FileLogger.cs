using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        public string Path { get; set; }

        public FileLogger(string path)
        {
            Path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            List<string> contents = new List<string>
            {
                DateTime.Now.ToString(),
                ClassName,
                logLevel.ToString(),
                message
            };

            Console.WriteLine(Path);

            File.AppendAllLines(Path, contents);
        }
    }
}
