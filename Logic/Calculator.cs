using Calculator.Logic.Operations;
using Calculator.Logic.Operations.MyOperations;
using System;
using System.Collections.Generic;

namespace Calculator.Logic
{
    //Jedyna i główna klasa dostępna dla widoku, dostawca danych na główną logike (z myślą o możliwości podpięcia jako referencje w innym projekcie)
    public class Calculator
    {
        //Wyświetlana lista operacji
        public string TopNumber { get; private set; }
        //Wyświetlany wynik lub wpisywana liczba
        public string BottomNumber { get; private set; }
        //Wskazuje czy tryb wpisywania liczb do obliczania mediany jest aktywny
        public bool MedianOperation { get; private set; }

        IOperation MainOperation;
        ParseHistory parseHistory;

        public Calculator()
        {
            Inicialize(0);
        }

        public Calculator(double number)
        {
            Inicialize(number);
        }

        private void Inicialize(double number)
        {
            MainOperation = new Operation(number);
            parseHistory = new ParseHistory(this);
            RefreashStats();
        }

        #region Operations

        public void Addition()
        {
            Run(MainOperation.Run, new Addition(MainOperation));
        }

        public void Division()
        {
            Run(MainOperation.Run, new Division(MainOperation));
        }

        public void Multiplication()
        {
            Run(MainOperation.Run, new Multiplication(MainOperation));
        }

        public void Fibonacci()
        {
            Run(MainOperation.Run, new Fibonacci(MainOperation));
        }

        public void Median()
        {
            Run(MainOperation.Run, new Median(MainOperation));
        }

        public void Percent()
        {
            Run(MainOperation.Run, new Percent(MainOperation));
        }

        public void PowClass()
        {
            Run(MainOperation.Run, new PowClass(MainOperation));
        }

        public void SqrtClass()
        {
            Run(MainOperation.Run, new SqrtClass(MainOperation));
        }

        public void Subtraction()
        {
            Run(MainOperation.Run, new Subtraction(MainOperation));
        }

        public void MedianSetValue()
        {
            if(MedianOperation)
                Run(MainOperation.Run, MainOperation.MyMedian);
        }

        #endregion

        public void LoadCalculatorFromHistory(int index)
        {
            //Tworzenie nowej operacji z historii
            if (parseHistory.CheckIndex(index))
            {
                MainOperation = new Operation(0);
                MedianOperation = false;
                parseHistory.CreateNewOperationFromHistory(index);
                RefreashStats();
            }
        }

        //Pobieranie i sprawdzanie poprawności historii w pliku
        public List<string> GetHistoryList()
        {
            return parseHistory.ConvertHistory(MainOperation.GetHistoryList());
        }

        //Dodajemy nowy znak do liczby
        public void NewSignToNumber(string n)
        {
            MainOperation.SetActualNumber(n);
            RefreashStats();
        }

        //Usuwamy znak z liczby
        public void BackSpace()
        {
            MainOperation.BackSpace();
            RefreashStats();
        }

        //Resetujemy wszystko
        public void Clear()
        {
            MainOperation.Clear();
            RefreashStats();
            MedianOperation = false;
        }

        //Uzyskujemy wynik
        public void GetResult()
        {
            if (MedianOperation)
            {
                MedianStop();
                return;
            }
            MainOperation = new Operation(MainOperation.Solve());
            RefreashStats();
        }

        public void MedianStart()
        {
            MainOperation.StartMedian();
            MedianOperation = true;
        }

        private void MedianStop()
        {
            MainOperation.StopMedian();
            MedianOperation = false;
            RefreashStats();
        }

        private void Run(Action<DoubleOperation> action, DoubleOperation operation)
        {
            action.Invoke(operation);
            RefreashStats();
        }

        private void Run(Action<SingleOperation> action, SingleOperation operation)
        {
            action.Invoke(operation);
            RefreashStats();
        }

        private void RefreashStats()
        {
            TopNumber = MainOperation.TopNumber;
            BottomNumber = MainOperation.BottomNumber;
        }
    }
}
