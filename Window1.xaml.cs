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
        public Window1()
        {
            InitializeComponent();
            windooow.Title = Exchange.s;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("somescript.bat",
                @"dir /b " + path + " > otv.txt");
            Process.Start("somescript.bat");
            dirinfo.Text = File.ReadAllText("otv.txt");
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
    }
}
