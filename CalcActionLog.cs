using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c6_Calc
{
    internal enum CalcAction
    {
        Divide,
        Multiply,
        Sum,
        Subtract
    }
    internal class CalcActionLog
    {
        public double Argument { get; private set; }
        public CalcAction CalcAction { get; private set; }

        public CalcActionLog(double argument, CalcAction calcAction)
        {
            Argument = argument;
            CalcAction = calcAction;
        }
        public override string ToString()
        {
            return CalcAction + " " + Argument + " ";
        }

    }
}
