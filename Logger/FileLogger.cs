using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {

        private string Path { get; set; }

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
            File.AppendAllLines(Path, contents);
        }
    }
}
