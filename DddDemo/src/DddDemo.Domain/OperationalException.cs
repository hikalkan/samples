using System;
using DddDemo.Issues;

namespace DddDemo
{
    public class OperationalException : Exception
    {
        public string Type { get; }

        public OperationalException(string type, string message = null)
            : base(message)
        {
            Type = type;
        }
    }
}