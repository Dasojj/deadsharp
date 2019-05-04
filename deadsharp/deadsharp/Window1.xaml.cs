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
        public string path = @"C:\Users\assasinfil\source\repos\KirillM281\deadsharp\deadsharp\deadsharp\bin\Debug";
        private Process proc = new Process();
        private Thread t;

        public Window1()
        {
            InitializeComponent();
            windooow.Title = Exchange.s;
            proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    CreateNoWindow = true
                };
            proc.Start();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            t = new Thread(new ThreadStart(doIt));
            t.IsBackground = true;
            t.Start();
        }
        private void doIt()
        {
            proc.StandardInput.WriteLine("@cd " + path + "\n");
            proc.StandardInput.WriteLine("@dir /b\n");
            dirinfo.Dispatcher.Invoke(new Action(() => { dirinfo.Text = ""; }));
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                dirinfo.Dispatcher.Invoke(new Action(() => { dirinfo.Text += line + "\n"; }));
            }
            proc.WaitForExit();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to change an output type?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
            }
        }
    }
}
