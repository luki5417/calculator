using System.Linq;

namespace Calculator.Logic.Operations
{
    public abstract class DoubleOperation : BasicOperation
    {
        public double FirstNumber { get; set; }

        public DoubleOperation(IOperation operationClass) : base(operationClass) { }

        public override void AddToList()
        {
            var myList = OperationClass.OperationList;
            myList.Add(new MyNumber(OperationClass, OperationClass.ActualNumber));
            myList.Add(this);

            //Sprawdzanie czy wartość już jest wpisana w liste operacji
            int lenght = myList.Count;
            if (lenght > 2)
            {
                //Sprawdzamy czy poprzednia operacja to SingleOperation jeśli tak to usuwamy dodaną wyżej wyliczoną zmienną
                if (myList[lenght - 3] is SingleOperation)
                    myList.RemoveAt(lenght - 2);
            }
            //Do pliku zapisujemy dopiero od drugiej operacji
            //if(myList.Count > 2)
                OperationClass.SaveToFile(new string[] { myList[myList.Count - 2].StringToFile, myList[myList.Count - 1].StringToFile });
            OperationClass.RefreashActNumber = true;
        }

        public bool CheckStatus()
        {
            var myList = OperationClass.OperationList;

            if (myList.Count > 0)
            {
                if (OperationClass.RefreashActNumber && myList.Last() is DoubleOperation)
                {
                    myList.RemoveAt(myList.Count - 1);
                    myList.Add(this);
                    return false;
                }
            }
            return true;
        }

        public void RunLastOperation()
        {
            if (OperationClass.LastOperationObject != null)
                OperationClass.LastOperationObject.Run();
        }

        public void SaveActualOperation()
        {
            var op = OperationClass;
            op.LastOperationObject = this;
            op.LastOperationObject.FirstNumber = op.ActualNumber;
        }

        public void RefreashProperty()
        {
            RefreashProperty(OperationClass.ActualNumber.ToString());
        }
    }
}
