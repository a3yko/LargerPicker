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

namespace Larger_Picker
{   
    public delegate bool change(int num1, int num2);
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static event change com;
        int[] arr = new int[100];
        int[] arr2 = new int[100];
        int k = 0;
        int right = 0;
        int wrong = 0;
        change b1 = new change(MainWindow.check);
        change b2 = new change(MainWindow.check);
        Random randNum = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(5, 500);
                arr2[i] = randNum.Next(15, 500);
            }
            for(int i = 0; i<arr.Length; i++)
            {
                if(arr[i] == arr2[i])
                {
                    arr[i] = randNum.Next(arr[i] + 1, 500);
                }
            }
            rgt.Text = "0";
            wrg.Text = "0";
            oneText.IsReadOnly = true;
            twoText.IsReadOnly = true;
        }

        private void clickLeft(object sender, RoutedEventArgs e)
        {     
            if (k == 100)
                k = 0;
            oneText.Text = arr[k].ToString();
            twoText.Text = arr2[k].ToString();
            one.IsEnabled = false;
            two.IsEnabled = false;
            com +=  new change(check);
            bool val = com(arr[k], arr2[k]);
            if (val)
            {
                k = k + 2;
                right++;
                rgt.Text = right.ToString();
            }
            else if(!val)
            {
                k = k + 2;
                wrong++;
                wrg.Text = wrong.ToString();
            }
        }

        private void nextClick(object sender, RoutedEventArgs e)
        {
            one.IsEnabled = true;
            two.IsEnabled = true;
            oneText.Text = "";
            twoText.Text = "";
            if (k == 0)
                k = 0;
        }

        private void clickRight(object sender, RoutedEventArgs e)
        {
            oneText.Text = arr[k].ToString();
            twoText.Text = arr2[k].ToString();
            one.IsEnabled = false;
            two.IsEnabled = false;
            com += new change(check);
            bool val = com(arr2[k], arr[k]);
            if (val)
            {
                k++;
                right++;
                rgt.Text = right.ToString();
            }
            else if (!val)
            {
                k++;
                wrong++;
                wrg.Text = wrong.ToString();
            }
        }

        static bool check(int selected, int otherNum)
        {
            if(selected > otherNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
