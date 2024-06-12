using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c6_Calc
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs>? GotResult;
        private double result = 0;
        public double Result { get => result; }
        Stack<double> stackResults = new Stack<double>();
        public List<CalcActionLog> Actions { get; private set; } = new List<CalcActionLog>();
        private const string OVERFLOWEXCEPTIONMESSAGE = "Выход за границы допустимого значения.";
        public void Sum(int i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Sum));
            try
            {
                checked
                {
                    result += i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }
        public void Sub(int i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Subtract));
            try
            {
                checked
                {
                    result -= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }
        public void Div(int i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Divide));
            try
            {
                checked
                {
                    result /= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (DivideByZeroException ex)
            {
                throw new CalculatorDivideByZeroException("Невозможно деление на ноль.", ex);
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }

        public void Mul(int i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Multiply));
            try
            {
                checked
                {
                    result *= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }

        public void Sum(double i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Sum));
            try
            {
                checked
                {
                    result += i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }
        public void Sub(double i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Subtract));
            try
            {
                checked
                {
                    result -= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }
        public void Div(double i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Divide));
            try
            {
                if(i== 0)
                    throw new DivideByZeroException();
                checked
                {
                    result /= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (DivideByZeroException ex)
            {
                throw new CalculatorDivideByZeroException("Невозможно деление на ноль.", ex);
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }

        public void Mul(double i)
        {
            Actions.Add(new CalcActionLog(i, CalcAction.Multiply));
            try
            {
                checked
                {
                    result *= i;
                    stackResults.Push(result);
                    GotResult?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (OverflowException ex)
            {
                throw new CalculateOperationCauseOverflowException(OVERFLOWEXCEPTIONMESSAGE, ex);
            }
        }

        public bool CancelLast()
        {
            if (stackResults.Count > 0)
            {
                stackResults.Pop();
                result = stackResults.TryPeek(out double a) ? a : 0;
                GotResult?.Invoke(this, EventArgs.Empty);
                Actions.RemoveAt(Actions.Count - 1);
                return true;
            }
            return false;
        }
    }
}
