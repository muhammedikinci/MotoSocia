using Application.Command;
using System;

namespace Application
{
    public class Log
    {
        public static void Write<TEventType, TLogType>(bool result) where TEventType : ICommand where TLogType : Log
        {
            Console.WriteLine($"[]Event type : {typeof(TEventType)} \n[]LogType {typeof(TLogType)} \n[]Process Result {result}");
        }
    }

    public class DatabaseLog : Log
    {
        
    }
}
