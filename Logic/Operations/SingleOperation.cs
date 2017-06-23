namespace Calculator.Logic.Operations
{
    public abstract class SingleOperation : BasicOperation
    {
        public SingleOperation(IOperation operationClass) : base(operationClass) { }

        public override void AddToList()
        {
            DeleteSingleOperation();
            OperationClass.OperationList.Add(this);
        }

        public void RefreashProperty()
        {
            RefreashProperty(OperationClass.ActualNumber.ToString());
            OperationClass.RefreashActNumber = true;
        }
    }
}
