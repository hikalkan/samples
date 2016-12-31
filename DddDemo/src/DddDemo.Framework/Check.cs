using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace DddDemo
{
    [DebuggerStepThrough]
    public static class Check //Should be moved to a framework!
    {
        [ContractAnnotation("value:null => halt")]
        public static T NotNull<T>(T value, [InvokerParameterName] [NotNull] string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }
    }
}
