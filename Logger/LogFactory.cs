using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string FilePath
        {
            get;
            set;
        }

        public BaseLogger CreateLogger(string className)
        {

            if (FilePath is null)
            {
                return null;
            }
            string path = Path.GetFullPath(FilePath);
            FileLogger fileLogger = new FileLogger(path)
            {
                ClassName = className
            };
            return fileLogger;


        }

        public BaseLogger CreateExtraCreditAdditionalLogger(string className)
        {
            ExtraCreditAddtionalLogger extraCreditAddtionalLogger = new ExtraCreditAddtionalLogger()
            {
                ClassName = className
            };
            return extraCreditAddtionalLogger;
        }

        public void ConfigureFileLogger(string path)
        {
            FilePath = path;
        }
    }
}
