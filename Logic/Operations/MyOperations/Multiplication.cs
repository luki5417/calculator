namespace Calculator.Logic.Operations.MyOperations
{
    public class Multiplication : DoubleOperation
    {
        public Multiplication(IOperation operationClass) : base(operationClass)
        {
            StringToFile = "Multiplication";
            Tag = "*";
        }

        public override void Run()
        {
            OperationClass.ActualNumber = FirstNumber * OperationClass.ActualNumber;
        }
    }
}
