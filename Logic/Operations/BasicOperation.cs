using System;
using System.Linq;

namespace Calculator.Logic.Operations
{
    public abstract class BasicOperation
    {
        public string Tag { get; set; }
        public string StringToFile { get; set; }
        protected Operation OperationClass;

        public BasicOperation(IOperation operationClass)
        {
            OperationClass = operationClass as Operation;
        }

        public virtual void Run() { }

        public virtual void AddToList() { }

        public virtual void DeleteSingleOperation()
        {
            if (OperationClass.OperationList.Count > 0)
            {
                var item = OperationClass.OperationList.Last();
                if (item is SingleOperation)
                    OperationClass.OperationList.RemoveAt(OperationClass.OperationList.Count - 1);
            }
        }

        protected void RefreashProperty(string n)
        {
            double result;
            Double.TryParse(n, out result);
            OperationClass.ActualNumber = result;
            OperationClass.BottomNumber = OperationClass.ActualNumber.ToString();
            OperationClass.TopNumber = String.Join(" ", OperationClass.OperationList.Select(x => x.Tag).ToArray());
        }
    }
}
