namespace Calculator.Logic.Operations.MyOperations
{
    public class Addition : DoubleOperation
    {                
        public Addition(IOperation operationClass) : base(operationClass)
        {
            StringToFile = "Addition";
            Tag = "+";
        }

        public override void Run()
        {
            OperationClass.ActualNumber =  FirstNumber + OperationClass.ActualNumber;
        }
    }
}
