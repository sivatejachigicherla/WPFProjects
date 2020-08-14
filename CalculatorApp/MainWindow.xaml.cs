using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            //resultLabel.Content = "9";
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(),out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber;
            }
        }

        private void percentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber/100;
                resultLabel.Content = lastNumber;
            }
        }


        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedNumber = 0;
            if(sender == zeroButton)
            {
                selectedNumber = 0;
            }
            else if (sender == oneButton)
            {
                selectedNumber = 1;
            }
            else if (sender == twoButton)
            {
                selectedNumber = 2;
            }
            else if (sender == threeButton)
            {
                selectedNumber = 3;
            }
            else if (sender == fourButton)
            {
                selectedNumber = 4;
            }
            else if (sender == fiveButton)
            {
                selectedNumber = 5;
            }
            else if (sender == sixButton)
            {
                selectedNumber = 6;
            }
            else if (sender == sevenButton)
            {
                selectedNumber = 7;
            }
            else if (sender == eightButton)
            {
                selectedNumber = 8;
            }
            else if (sender == nineButton)
            {
                selectedNumber = 9;
            }
            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedNumber}";
            }
        }



        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == plusButton)
            {
                selectedOperator = SelectedOperator.addition;
            }
            else if (sender == subButton)
            {
                selectedOperator = SelectedOperator.subtraction;
            }
            else if (sender == mulButton)
            {
                selectedOperator = SelectedOperator.multiplication;
            }
            else if (sender == divButton)
            {
                selectedOperator = SelectedOperator.division;
            }
        }


        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {

            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void eButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)  
                {
                    case (SelectedOperator.addition):
                        result = SimpleMath.Add(newNumber,lastNumber);
                        break;
                    case (SelectedOperator.subtraction):
                        result = SimpleMath.Sub(newNumber, lastNumber);
                        break;
                    case (SelectedOperator.multiplication):
                        result = SimpleMath.Mul(newNumber, lastNumber);
                        break;
                    case (SelectedOperator.division):
                        result = SimpleMath.Div(newNumber, lastNumber);
                        break;
                }
                resultLabel.Content = result;
            }
        }
    }
}
