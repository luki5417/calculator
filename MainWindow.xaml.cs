using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public Logic.Calculator myCalculator = new Logic.Calculator();
        History myHistory;

        public MainWindow()
        {
            InitializeComponent();
            myHistory = new History(this);
            ResultWindow.Text = myCalculator.BottomNumber;
        }

        #region Operations

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.SqrtClass();
        }

        private void Pow_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.PowClass();
        }

        private void Fibonacci_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Fibonacci();
        }

        private void Median_Click(object sender, RoutedEventArgs e)
        {
            if (!myCalculator.MedianOperation)
                myCalculator.MedianStart();
            else
                myCalculator.MedianSetValue();
        }

        private void Percent_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Percent();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Clear();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.BackSpace();
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Division();
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Multiplication();
        }

        private void Subtraction_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Subtraction();
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.Addition();
        }

        private void GetResult_Click(object sender, RoutedEventArgs e)
        {
            myCalculator.GetResult();
        }

        #endregion

        private void History_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Add(myHistory);
            myHistory.Load();
        }

        private void GetNumber(object sender, RoutedEventArgs e)
        {
            Button myButton = sender as Button;
            myCalculator.NewSignToNumber(myButton.Tag.ToString());
        }

        public void RefreashStat(object sender, RoutedEventArgs e)
        {
            ResultWindow.Text = myCalculator.BottomNumber;
            OperationWindow.Text = myCalculator.TopNumber;
            ChangeButtonsStat();
        }

        private void ChangeButtonsStat()
        {
            if (myAddition.IsEnabled == myCalculator.MedianOperation)
            {
                if (myCalculator.MedianOperation)
                    myMedian.Content = "+";
                else
                    myMedian.Content = "Me";
                myDivision.IsEnabled =
                myMultiplication.IsEnabled =
                myPercent.IsEnabled =
                mySubtraction.IsEnabled =
                myAddition.IsEnabled = !myCalculator.MedianOperation;
            }
        }
    }
}
