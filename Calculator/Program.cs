using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            GetOperationItems(out int operationId, out int firstNumber, out int secondNumber);
            var calc = new CalculatorEngine();
            double result = calc.DoOperation(operationId, firstNumber, secondNumber);
            Console.WriteLine("The result is: " + result);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void GetOperationItems(out int operationId, out int firstNumber, out int secondNumber)
        {
            Console.WriteLine("Enter operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Substract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            operationId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter first number");
            firstNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            secondNumber = int.Parse(Console.ReadLine());
        }
    }
}
