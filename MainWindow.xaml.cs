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

namespace Simple_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Maximum number length is smaller than 10
        double number;
        string sign;
        bool equal = false;
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            //Check if you just click Equal Button?
            if (equal == false)
            {
                Button btt = sender as Button;
                if (Screen.Text.Length < 9)
                    Screen.Text += btt.Content;
            }
            else
                Small_Screen.Text = "Need clear screen";
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            Button btt = sender as Button;
            string is_minus = btt.Content as string;
            if (Screen.Text != "")
            {
                if (Screen_Sign.Text == "")
                {
                    number = double.Parse(Screen.Text);
                    Screen.Text = "";
                    Small_Screen.Text = $"{number}";
                }
                sign = btt.Content as string;
                Screen_Sign.Text = sign;
            }
            //For negative number (Only first number can be negative)
            else if (Screen.Text == "" && is_minus == "-" && Screen_Sign.Text == "")
            {
                Number_Click(sender, e);
            }
            equal = false;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text != "" && equal == false)
            {
                if (sign == "+")
                    number += double.Parse(Screen.Text);
                else if (sign == "-")
                    number -= double.Parse(Screen.Text);
                else if (sign == "x")
                    number *= double.Parse(Screen.Text);
                else if (sign == "/")
                {
                    if (Screen.Text == "0")
                    {
                        Screen.Text = "Cannot divide by 0";
                        equal = true;
                        return;
                    }
                    number /= double.Parse(Screen.Text);
                }
                else
                    number = double.Parse(Screen.Text);
                Screen.Text = $"{number}";
                //Remove sign of screen
                Screen_Sign.Text = "";
                //Remove small screen display
                Small_Screen.Text = "";
                //Make equal = true to back to Button_Click through Clear_Click
                equal = true;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //Return to default value
            number = 0;
            sign = "";
            Screen.Text = "";
            Screen_Sign.Text = "";
            Small_Screen.Text = "";
            equal = false;
        }
    }
}
