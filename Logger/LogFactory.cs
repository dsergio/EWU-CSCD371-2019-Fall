using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        public string FilePath {
            get;
            private set;
        }

        public BaseLogger CreateLogger(string className)
        {
            if (className == "FileLogger")
            {
                if (FilePath is null)
                {
                    return null;
                }
                string path = Path.GetFullPath(FilePath);
                FileLogger fileLogger = new FileLogger(path)
                {
                    ClassName = "FileLogger"
                };
                return fileLogger;
            }
            return null;
        }

        public void ConfigureFileLogger(string path)
        {
            FilePath = path;
        }
    }
}
