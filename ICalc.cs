using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c6_Calc
{
    internal interface ICalc
    {
        event EventHandler<EventArgs>? GotResult;
        void Sum(int i);
        void Sub(int i);
        void Div(int i);
        void Mul(int i);
        bool CancelLast();
    }
}
