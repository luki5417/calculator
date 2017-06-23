namespace Calculator.Logic.Operations.MyOperations
{
    public class Percent : DoubleOperation
    {
        public Percent(IOperation operationClass) : base(operationClass)
        {
            StringToFile = "Percent";
            Tag = "%";
        }

        public override void Run()
        {
            OperationClass.ActualNumber = FirstNumber * OperationClass.ActualNumber / 100;
        }
    }
}
