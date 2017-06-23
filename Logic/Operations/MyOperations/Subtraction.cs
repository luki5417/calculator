namespace Calculator.Logic.Operations.MyOperations
{
    public class Subtraction : DoubleOperation
    {
        public Subtraction(IOperation operationClass) : base(operationClass)
        {
            StringToFile = "Subtraction";
            Tag = "-";
        }

        public override void Run()
        {
            OperationClass.ActualNumber = FirstNumber - OperationClass.ActualNumber;
        }
    }
}
