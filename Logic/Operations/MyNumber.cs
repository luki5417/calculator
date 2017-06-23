using Calculator.Logic.Operations.MyOperations;
using System.Linq;

namespace Calculator.Logic.Operations
{
    //Metody wykonują się w momencie zmianyaktualnej liczby
    public class MyNumber : BasicOperation
    {
        public MyNumber(IOperation operationClass, double number) : base(operationClass)
        {
            Tag = StringToFile = number.ToString();
        }

        public MyNumber(IOperation operationClass, string number) : base(operationClass)
        {
            Tag = StringToFile = number;
        }

        public MyNumber(IOperation operationClass) : base(operationClass) { }

        public override void AddToList()
        {
            DeleteSingleOperation();
            RefreashProperty(Tag);
            OperationClass.RefreashActNumber = false;
        }

        public override void DeleteSingleOperation()
        {
            if (OperationClass.OperationList.Count > 0)
            {
                var item = OperationClass.OperationList.Last();
                //Usuwamy gdy obiekt jest typu SingleOperation (za wyjątkiem mediany)
                //Gdy Mediana jest aktywna dajemy tym samym użytkownikowi ciągły podgląd wpisanych już liczb
                if (item is SingleOperation && !(item is Median))
                    OperationClass.OperationList.RemoveAt(OperationClass.OperationList.Count - 1);
            }
        }

        public void RefreashProperty(double d)
        {
            RefreashProperty(d.ToString());
        }
    }
}
