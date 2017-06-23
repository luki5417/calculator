using System;
using System.Collections.Generic;

namespace Calculator.Logic.Operations.MyOperations
{
    public class Median : SingleOperation
    {
        public bool Active { get; private set; }

        List<double> Numbers = new List<double>();

        public Median(IOperation operationClass) : base(operationClass) { }

        public override void Run()
        {
            if (!Active)
                return;

            Numbers.Add(OperationClass.ActualNumber);
            OperationClass.ActualNumber =  Response();
        }

        private double Response()
        {
            Tag = String.Format("me({0})", String.Join("; ", Numbers.ToArray()));

            List<double> listMedian = new List<double>();
            Numbers.ForEach(x => listMedian.Add(x));
            listMedian.Sort();

            int count = listMedian.Count;

            int kk = count / 2;

            if (count % 2 == 0)
                return (listMedian[(count / 2) - 1] + listMedian[count / 2]) / 2;
            else
                return listMedian[count / 2];
        }

        public void Start()
        {
            Active = true;
        }

        public void Stop()
        {
            List<string> listValue = new List<string>();
            Numbers.ForEach(x => listValue.Add(String.Format("{0};MedianSetValue", x)));
            StringToFile = String.Format("MedianStart;{0};MedianStop", String.Join(";", listValue));
            Numbers.Clear();
            Active = false;
        }
    }
}
