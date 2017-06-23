using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Calculator.Logic.Operations
{
    public class History
    {
        string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\History.txt";

        public History()
        {
            CheckExist();
            File.AppendAllText(path, Environment.NewLine);
        }

        public void Send(string code)
        {
            //Wyciąga ostatnią linie do stringa
            CheckExist();

            if (new FileInfo(path).Length > 0)
            {
                var lastLine = File.ReadLines(path).Last();
                DeleteLastLine();
                if(!String.IsNullOrEmpty(lastLine))
                    File.AppendAllText(path, String.Format("{0};{1}", lastLine, code));
                else
                    File.AppendAllText(path, code);
            }           
            else
            {
                File.AppendAllText(path, code);
            }
        }

        public List<string> AllHistory()
        {
            CheckExist();
            return File.ReadAllLines(path).ToList();
        }

        private void DeleteLastLine()
        {
            var lines = File.ReadAllLines(path);
            File.WriteAllLines(path, lines.Take(lines.Length - 1).ToArray());
        }

        private void CheckExist()
        {
            if (!File.Exists(path))
                File.Create(path).Close();
        }
    }
}
