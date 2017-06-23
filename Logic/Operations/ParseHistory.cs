using System;
using System.Collections.Generic;
using System.Reflection;

namespace Calculator.Logic.Operations
{
    public class ParseHistory
    {
        Calculator calculator;
        Dictionary<string, string> Signs = new Dictionary<string, string>();
        List<string> Codes = new List<string>();

        public ParseHistory(Calculator cal)
        {
            calculator = cal;

            //Tworzenie znaków dla użytkownika (używane tylko do wyświetlania rekordów z historii)
            #region Signs

            Signs.Add("Clear", "C");
            Signs.Add("GetResult", "=");
            Signs.Add("MedianSetValue", ";");
            Signs.Add("Subtraction", "-");
            Signs.Add("SqrtClass", "sqrt");
            Signs.Add("PowClass", "pow");
            Signs.Add("Percent", "%");
            Signs.Add("MedianStart", "me(");
            Signs.Add("MedianStop", ")");
            Signs.Add("Fibonacci", "fib");
            Signs.Add("Multiplication", "*");
            Signs.Add("Division", "/");
            Signs.Add("Addition", "+");

            #endregion
        }

        //Wykonuje metody na nowej operacji (Operation)
        public void CreateNewOperationFromHistory(int index)
        {
            string code = Codes[index];

            string[] data = code.Split(';');

            foreach (var item in data)
            {                
                MethodInfo theMethod = CheckMethod(item);
                if (theMethod != null)
                    theMethod.Invoke(calculator, null);
                else
                {
                    double myDouble = 0;
                    if (CheckDouble(item, ref myDouble))
                    {
                        calculator.NewSignToNumber(myDouble.ToString());
                    }
                }
            }
        }

        public bool CheckIndex(int i)
        {
            //Sprawdza czy index jest poza listą
            if (i < 0 || i > Codes.Count - 1)
                return false;
            return true;
        }

        //Wyprowadza dane z pliku
        public List<string> ConvertHistory(List<string> data)
        {
            Codes.Clear();
            List<string> response = new List<string>();

            foreach(var item in data)
            {
                var responseElement = CheckHistoryElement(item);

                if(responseElement != null)
                {
                    Codes.Add(item);
                    response.Add(String.Join(" ", responseElement));
                }
            }
            return response;
        }

        private List<string> CheckHistoryElement(string data)
        {
            //Łapie błąd jeśli danych jest za mało
            string[] xData = data.Split(';');
            if (xData.Length < 2)
                return null;

            return ConvertElement(xData);
        }

        //Wyłapuje błędne dane, jeśli wykryje niezgodność w elemencie nie będzie go brał pod uwagę
        private List<string> ConvertElement(string[] data)
        {
            List<string> ToShow = new List<string>();
            foreach (var item in data)
            {
                var theMethod = CheckMethod(item);
                if (theMethod == null && !CheckDouble(item))
                {
                    return null;
                }
                if (theMethod != null)
                {
                    ToShow.Add(Signs[item]);
                    continue;
                }
                ToShow.Add(item);
            }
            return ToShow;
        }

        private MethodInfo CheckMethod(string item)
        {
            return calculator.GetType().GetMethod(item, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        private bool CheckDouble(string item, ref double myDouble)
        {
            myDouble = 0;
            return Double.TryParse(item, out myDouble);           
        }

        private bool CheckDouble(string item)
        {
            double myDouble = 0;
            return Double.TryParse(item, out myDouble);
        }
    }
}
