using System;

namespace Calculator.Logic.Operations.MyOperations
{
    public class PowClass : SingleOperation
    {
        public PowClass(IOperation operationClass) : base(operationClass) { }

        public override void Run()
        {
            var num = OperationClass.ActualNumber;
            Tag = String.Format("pow({0})", num);
            StringToFile = String.Format("{0};PowClass", num);
            OperationClass.ActualNumber = Math.Pow(num, 2);
        }
    }
}
