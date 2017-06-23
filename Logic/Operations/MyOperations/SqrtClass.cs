using System;

namespace Calculator.Logic.Operations.MyOperations
{
    public class SqrtClass : SingleOperation
    {
        public SqrtClass(IOperation operationClass) : base(operationClass) { }

        public override void Run()
        {
            var num = OperationClass.ActualNumber;
            Tag = String.Format("sqrt({0})", num);
            StringToFile = String.Format("{0};SqrtClass", num);
            OperationClass.ActualNumber = Math.Sqrt(num);
        }
    }
}
