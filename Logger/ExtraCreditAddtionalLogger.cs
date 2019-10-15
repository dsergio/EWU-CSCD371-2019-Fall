using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Logger
{
    public class ExtraCreditAddtionalLogger : BaseLogger
    {

        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public ExtraCreditAddtionalLogger()
        {
            
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

            Trace.AutoFlush = true;
            Trace.Indent();

            Trace.WriteLine("In constructor");
        }

        public override void Log(LogLevel logLevel, string message)
        {

            LoggedMessages.Add((logLevel, message));

            List<string> contents = new List<string>
            {
                DateTime.Now.ToString(),
                ClassName,
                logLevel.ToString(),
                message
            };

            StringBuilder sb = new StringBuilder();
            foreach (string s in contents)
            {
                sb.Append(s + " ");
            }

            sb.Append("LoggedMessages.Count: " + LoggedMessages.Count);

            string str = sb.ToString();


            if (logLevel == LogLevel.Debug)
            {
                Trace.WriteLine(str);
            } 
            else if (logLevel == LogLevel.Error)
            {
                Trace.TraceError(str);
            }
            else if (logLevel == LogLevel.Information)
            {
                Trace.TraceInformation(str);
            }
            else if (logLevel == LogLevel.Warning)
            {
                Trace.TraceWarning(str);
            }
            Trace.Unindent();
        }
    }
}
