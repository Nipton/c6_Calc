namespace c6_Calc
{
    internal class Program
    {
        static void PrintResult(object sender, EventArgs e)
        {
            Console.WriteLine("Результат: " + (sender as Calculator)?.Result);
        }
        static void IncorrectInput(double result, Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.WriteLine("\nРезультат: " + result);
        }
        static void IncorrectInputWithLog(Calculator calc, Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.WriteLine("последовательность действий приведших исключению: ");
            Console.Write("0 ");
            foreach (var item in calc.Actions)
            {
                Console.Write(item);
            }
            Console.WriteLine("\nРезультат: " + calc.Result);
            calc.Actions.RemoveAt(calc.Actions.Count - 1);
        }
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            calc.GotResult += PrintResult;

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1) Сложение.");
                Console.WriteLine("2) Вычитание.");
                Console.WriteLine("3) Умножение.");
                Console.WriteLine("4) Деление.");
                Console.WriteLine("5) Отменить последнюю операцию.");
                Console.WriteLine("0) Выход.");
                string input = Console.ReadLine()!;
                switch (input)
                {
                    case "1":
                        Console.Write("Введите число: ");
                        try 
                        {
                            double result = double.Parse(Console.ReadLine()!);
                            Console.Clear();
                            calc.Sum(result);
                            Console.WriteLine();
                        }
                        catch (CalculateOperationCauseOverflowException ex)
                        {
                            IncorrectInputWithLog(calc, ex);
                        }
                        catch (Exception ex)
                        {
                            IncorrectInput(calc.Result, ex);
                        }
                        break;
                    case "2":
                        Console.Write("Введите число: ");
                        try
                        {
                            double result2 = double.Parse(Console.ReadLine()!);
                            Console.Clear();
                            calc.Sub(result2);
                            Console.WriteLine();
                        }
                        catch (CalculateOperationCauseOverflowException ex)
                        {
                            IncorrectInputWithLog(calc, ex);
                        }
                        catch (Exception ex)
                        {
                            IncorrectInput(calc.Result, ex);
                        }
                        break;
                    case "3":
                        Console.Write("Введите число: ");
                        try
                        {
                            double result3 = double.Parse(Console.ReadLine()!);
                            Console.Clear();
                            calc.Mul(result3);
                            Console.WriteLine();
                        }
                        catch (CalculateOperationCauseOverflowException ex)
                        {
                            IncorrectInputWithLog(calc, ex);
                        } 
                        catch (Exception ex)
                        {
                            IncorrectInput(calc.Result, ex);
                        }
                        break;
                    case "4":
                        Console.Write("Введите число: ");
                        try
                        {
                            double result4 = double.Parse(Console.ReadLine()!);
                            Console.Clear();
                            calc.Div(result4);
                            Console.WriteLine();
                        }
                        catch (CalculatorDivideByZeroException ex)
                        {
                            IncorrectInputWithLog(calc, ex);
                        }
                        catch (CalculateOperationCauseOverflowException ex)
                        {
                            IncorrectInputWithLog(calc, ex);
                        }
                        catch (Exception ex)
                        {
                            IncorrectInput(calc.Result, ex);
                        }
                        break;
                    case "5":
                        Console.Clear();
                        if (calc.CancelLast())
                        {
                            Console.WriteLine("Последняя операция отменена.\n");
                        }
                        else
                        {
                            Console.WriteLine("Нет операции, которую можно отменить.\n");
                        }
                        break;
                    case "0":
                        return;
                    case "":
                        return;
                    default:
                        IncorrectInput(calc.Result, new Exception("Неверный ввод"));
                        break;
                }
            }
        }
    }
}