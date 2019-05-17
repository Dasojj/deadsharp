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
using System.Timers;

namespace deadsharp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    
    public partial class Window1 : Window
    {
        public string path = @"C:\Users\";
        public string[] ars;
        public int I = 0;
        public Window1()
        {
            InitializeComponent();
            windooow.Title = Exchange.s;
            pathtb.Text = path;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("somescript.bat",
                @"dir /b " + path + " > otv.txt");
            Process.Start("somescript.bat");
            dirinfo.Text = File.ReadAllText("otv.txt");
            ars = File.ReadAllLines("otv.txt");
            I = 0;
            if (ars.Length != 0)
            {
                ch_cd.IsEnabled = true;
                levo.IsEnabled = true;
                pravo.IsEnabled = true;
                ch_cd.Content = ars[I];
            }
            else
            {
                ch_cd.IsEnabled = false;
                levo.IsEnabled = false;
                pravo.IsEnabled = false;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to return to the main menu?",
            "Your data will be lost", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow mn1 = new MainWindow();
                mn1.Show();
                this.Close();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pathtb.Text += "\\";
            path = pathtb.Text;
        }

        private void Ch_cd_Click(object sender, RoutedEventArgs e)
        {
            path += (ch_cd.Content + "\\");
            pathtb.Text = path;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (I > 0)
            {
                I--;
                ch_cd.Content = ars[I];
            }
            else MessageBox.Show("It`s the 1st name in list");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (I < ars.Length-1)
            {
                I++;
                ch_cd.Content = ars[I];
            }
            else MessageBox.Show("It`s the last name in list");
        }
    }
}
