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

namespace deadsharp
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

        //Здесь запускаем окно с сессией, в зависимости от выбранного типа
        //Выбираем тип сессии для пользователя(работа с файлами и директориями; сетевые операции(самое сложное); работа с текстом, батниками, запуском приложений)
        private void Starting_Click(object sender, RoutedEventArgs e)
        {
            Exchange.s = sname.Text;
            if (filebt.IsChecked == true)
            {
                Window1 mn = new Window1();
                mn.Show();
                this.Close();
            }
            else if(netbt.IsChecked == true)
            {
                Window2 mn2 = new Window2();
                mn2.Show();
                this.Close();
            }
        }
    }
}
