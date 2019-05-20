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
        List<string> tmp = new List<string>();
        public int I = 0;
        public Window1()
        {
            InitializeComponent();
            windooow.Title = Exchange.s;
            pathtb.Text = path;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tmp.Clear();
            File.WriteAllText("somescript.bat",
            @"dir /b " + path + " > otv.txt");
            Process.Start("somescript.bat");
            dirinfo.Text = File.ReadAllText("otv.txt");
            tmp.AddRange(File.ReadAllLines("otv.txt"));
            for (int i = 0; i < tmp.Count; i++)
            {
                if(!(Directory.Exists(path + tmp[i])))
                {
                    tmp.RemoveAt(i);
                }
            }
            I = 0;
            if (tmp.Count != 0)
            {
                ch_cd.IsEnabled = true;
                levo.IsEnabled = true;
                pravo.IsEnabled = true;
                ch_cd.Content = tmp[I];
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
            ch_cd.IsEnabled = false;
            levo.IsEnabled = false;
            pravo.IsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (I > 0)
            {
                I--;
                ch_cd.Content = tmp[I];
            }
            else MessageBox.Show("It`s the 1st name in list");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (I < tmp.Count - 1)
            {
                I++;
                ch_cd.Content = tmp[I];
            }
            else MessageBox.Show("It`s the last name in list");
        }

        private void Opentxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtfilesmain.Text = File.ReadAllText(path + fname.Text);
            }
            catch
            {
                MessageBox.Show("No such file, enter the correct filename");
            }
        }

        private void Savetxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.WriteAllText(path + fname.Text, txtfilesmain.Text);
                MessageBox.Show("Сохранено");
            }
            catch
            {
                MessageBox.Show("Здесь нельзя создавать файлы");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?",
           "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                File.WriteAllText("somescript.bat",
                @"del " + path + delname.Text);
                Process.Start("somescript.bat");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("somescript.bat",
            @"mkdir " + path + mkdname.Text);
            Process.Start("somescript.bat");
            MessageBox.Show("Успешно");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?",
           "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (MessageBox.Show("Are you REALLY sure?",
           "CONFIRMATION", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    File.WriteAllText("somescript.bat",
                    @"rd /s /q " + path + deldirname.Text);
                    Process.Start("somescript.bat");
                }
            }
        }
    }
}
