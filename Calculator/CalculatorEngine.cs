using System;

namespace Calculator
{
    internal class CalculatorEngine
    {
        public CalculatorEngine()
        {
        }

        internal int DoOperation(int operationId, int firstNumber, int secondNumber)
        {
            switch (operationId)
            {
                case 1:
                    return Add(firstNumber, secondNumber);
                case 2:
                    return Substract(firstNumber, secondNumber);
                case 3:
                    return Multiply(firstNumber, secondNumber);
                case 4:
                    return Divide(firstNumber, secondNumber);
                default:
                    throw new InvalidOperationException($"The operation Id {operationId} is invalid.");

            }
        }

        private int Add(int firstNumber, int secondNumber)
        {
            var result = firstNumber + secondNumber;
            return result;
        }

        private int Substract(int firstNumber, int secondNumber)
        {
            var result = firstNumber - secondNumber;
            return result;
        }

        private int Multiply(int firstNumber, int secondNumber)
        {
            var result = firstNumber * secondNumber;
            return result;
        }

        private int Divide(int firstNumber, int secondNumber)
        {
            var result = firstNumber / secondNumber;
            return result;
        }

    }
}