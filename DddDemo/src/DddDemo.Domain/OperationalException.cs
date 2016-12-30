using System;
using DddDemo.Issues;

namespace DddDemo
{
    public class OperationalException : Exception
    {
        public OperationalExceptionType Type { get; }

        public OperationalException(OperationalExceptionType type, string message)
            : base(message)
        {
            Type = type;
        }
    }
}