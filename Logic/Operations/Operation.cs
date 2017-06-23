using Calculator.Logic.Operations.MyOperations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Logic.Operations
{
    public class Operation : IOperation
    {
        public string TopNumber { get; set; }
        public string BottomNumber { get; set; }
        public Median MyMedian { get; set; }

        public double ActualNumber;
        public bool RefreashActNumber;

        public DoubleOperation LastOperationObject;
        public List<BasicOperation> OperationList = new List<BasicOperation>();

        private History history = new History();

        public Operation(double actualNumber)
        {
            ActualNumber = actualNumber;
            BottomNumber = ActualNumber.ToString();
            RefreashActNumber = false;
        }

        //Zapis do pliku
        public void SaveToFile(string[] items)
        {
            history.Send(String.Join(";", items));
        }

        public List<string> GetHistoryList()
        {
            return history.AllHistory();
        }

        //Ustawianie wpisywanych wartości
        public void SetActualNumber(string myString)
        {
            //Zerowanie wartości po użyciu dowolnej operacji logicznej
            if (RefreashActNumber)
            {
                new MyNumber(this).RefreashProperty(0);
                RefreashActNumber = false;
            }
            //Obsługa wartości ujemnej z widoku
            if (myString == "-")
            {
                ActualNumber = ActualNumber * -1;
                BottomNumber = ActualNumber.ToString();
                return;
            }
            //Obsługa przecinka
            if (myString == ",")
            {
                if (!BottomNumber.Any(x => x == ','))
                    BottomNumber += myString;
                return;
            }
            BottomNumber += myString;
            //Odświerzanie
            new MyNumber(this, BottomNumber).AddToList();
        }

        //Usuwa ostatni znak z liczby
        public void BackSpace()
        {
            string value = BottomNumber;
            if (value.Length < 2)
                new MyNumber(this).RefreashProperty(0);
            else
            {
                value = value.Remove(value.Length - 1);
                BottomNumber = value;
                if (value.Last() == ',' || value.Last() == '-')
                    return;
            }
            new MyNumber(this, BottomNumber).AddToList();
        }

        //Obsługa operacji z jedną wartością
        public void Run(SingleOperation myOperation)
        {
            //Zapis nowego wyniku
            myOperation.Run();
            myOperation.AddToList();
            myOperation.RefreashProperty();
        }

        //Obsługa operacji z dwoma wartościami
        public void Run(DoubleOperation myOperation)
        {
            //Jeśli nie zostało nic wpisane i ostatnia operacja jest typu DoubleOperation to nie wykonuje działania
            if (myOperation.CheckStatus())
            {
                myOperation.AddToList();
                myOperation.RunLastOperation();
            }

            //Zapis aktualnej operacji
            myOperation.SaveActualOperation();

            //Odświerzanie
            myOperation.RefreashProperty();
        }

        //Otrzymanie wyniku
        public double Solve()
        {
            //Zapis do pliku ostatniej instrukcji
            SaveToFile(new string[] { ActualNumber.ToString(), "GetResult" });
            if(LastOperationObject != null)
                LastOperationObject.RunLastOperation();

            //Zapis do pliku wyniku
            SaveToFile(new string[] { ActualNumber.ToString(), "GetResult" });
            return ActualNumber;
        }

        //Przejście klasy do stanu początkowego
        public void Clear()
        {
            ActualNumber = 0;
            BottomNumber = ActualNumber.ToString();
            TopNumber = "";
            RefreashActNumber = false;
            LastOperationObject = null;
            MyMedian = null;
            OperationList.Clear();
            SaveToFile(new string[] { "Clear" });
        }

        public void StartMedian()
        {
            MyMedian = new Median(this);
            MyMedian.Start();
        }

        public void StopMedian()
        {
            Run(MyMedian);
            MyMedian.Stop();
            MyMedian = null;          
        }
    }
}
