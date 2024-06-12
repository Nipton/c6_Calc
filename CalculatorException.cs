using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c6_Calc
{
    internal class CalculatorException : Exception
    {
        public CalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    internal class CalculatorDivideByZeroException : CalculatorException
    {
        public CalculatorDivideByZeroException(string message, DivideByZeroException innerException) : base(message, innerException) 
        {
        }
    }
    internal class CalculateOperationCauseOverflowException : CalculatorException
    {
        public CalculateOperationCauseOverflowException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
