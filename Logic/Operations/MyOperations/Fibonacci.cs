using System;

namespace Calculator.Logic.Operations.MyOperations
{
    public class Fibonacci : SingleOperation
    {
        public Fibonacci(IOperation operationClass) : base(operationClass) { }

        public override void Run()
        {
            var number = OperationClass.ActualNumber;
            Tag = String.Format("fib({0})", number);
            StringToFile = String.Format("{0};Fibonacci", number);

            double elementA = 0, elementB = 1, result = 0;

            if (number < 2) return;
            for (double i = 2; i <= number; i++)
            {
                if (Double.IsInfinity(result))
                {
                    OperationClass.ActualNumber = result;
                    return;
                }
                result = elementA + elementB;
                elementA = elementB;
                elementB = result;
            }
            OperationClass.ActualNumber = result;
            return;
        }
    }
}
