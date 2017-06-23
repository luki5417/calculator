namespace Calculator.Logic.Operations.MyOperations
{
    public class Division : DoubleOperation
    {
        public Division(IOperation operationClass) : base(operationClass)
        {
            StringToFile = "Division";
            Tag = "/";
        }

        public override void Run()
        {
            OperationClass.ActualNumber = FirstNumber / OperationClass.ActualNumber;
        }
    }
}
