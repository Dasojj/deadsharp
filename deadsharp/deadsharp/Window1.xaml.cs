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
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace deadsharp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            windooow.Title = Exchange.s;
        }

        bool flag = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Батник или просто не создаётся, или создается непонятно где. В любом случае буду дебажить.
            if(flag == false)
            {
                File.WriteAllText("somescript.bat",
                @"cd C:\Users\" + " \n" +
                "dir /b > otv.txt \n");
                Process.Start("somescript.bat");
            }
           /* else
            {
                
            } */
            dirinfo.Text = File.ReadAllText("otv.txt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to change an output type?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (flag == false) flag = true;
                else flag = false;
            }
        }
    }
}
