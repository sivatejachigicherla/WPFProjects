using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WpfApp2
{
    class SimpleMath
    {
        public static double Add (double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Div(double n1, double n2)
        {
            if(n1 == 0)
            {
                MessageBox.Show("Division by zero","wrong operation",MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}
