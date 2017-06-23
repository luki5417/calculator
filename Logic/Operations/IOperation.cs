using Calculator.Logic.Operations.MyOperations;
using System.Collections.Generic;

namespace Calculator.Logic.Operations
{
    //Interfejs używany w widoku
    public interface IOperation
    {
        string TopNumber { get; set; }
        string BottomNumber { get; set; }
        Median MyMedian { get; set; }
        void SetActualNumber(string myString);
        void BackSpace();
        void Run(SingleOperation myOperation);
        void Run(DoubleOperation myOperation);
        List<string> GetHistoryList();
        double Solve();
        void Clear();
        void StopMedian();
        void StartMedian();
    }
}
