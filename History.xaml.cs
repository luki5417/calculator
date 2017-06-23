using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class History : UserControl
    {
        MainWindow mainWindow;

        public History(MainWindow mw)
        {
            InitializeComponent();
            mainWindow = mw;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Back();
        }

        public void Load()
        {
            myHis.Children.Clear();

            //Ładowanie z listy historii na widok
            var listHistory = mainWindow.myCalculator.GetHistoryList();
            for (int i = 0; i < listHistory.Count; i++)
            {
                Button myButton = new Button();
                myButton.Margin = new Thickness(2);
                myButton.BorderThickness = new Thickness(0);
                myButton.Click += ClickOnHistory;
                myButton.TabIndex = i;

                TextBlock myTextBlock = new TextBlock();
                myTextBlock.TextWrapping = TextWrapping.Wrap;
                myTextBlock.Text = listHistory[i];

                myButton.Content = myTextBlock;

                myHis.Children.Add(myButton);
            }
        }

        private void ClickOnHistory(object sender, RoutedEventArgs e)
        {
            Button myButton = sender as Button;

            mainWindow.myCalculator.LoadCalculatorFromHistory(myButton.TabIndex);
            mainWindow.RefreashStat(null, null);
            Back();
        }

        private void Back()
        {
            mainWindow.MainGrid.Children.Remove(this);
        }
    }
}
