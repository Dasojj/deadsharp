using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace deadsharp
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            windoooow.Title = Exchange.s;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to return to the main menu?",
            "Your data will be lost", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow mn1 = new MainWindow();
                mn1.Show();
                this.Close();
            }
        }


        //КОММЕНТЫ НЕ УДАЛЯТЬ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //КОММЕНТЫ НЕ УДАЛЯТЬ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //КОММЕНТЫ НЕ УДАЛЯТЬ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Здесь парсить надо
            //Хз как: можно в файле, можно в текстблоке
            //Ещё мб можно вывод сократить, типо как в дире, чтобы лишнее не писалось
            File.WriteAllText("somescript.bat",
            @"arp -a > otv.txt");
            Process.Start("somescript.bat");
            arpres.Text = File.ReadAllText("otv.txt");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Здесь начинаем делать всё, просим пользователя подождать минуту где-то, чтобы наверняка
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Здесь пишем вывод трассировки из файла, куда перенаправляли(otv.txt), когда пользователь подождал
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Стартуем пинг, пользователь ждет(по времени в зависимости от кол-ва пакетов)
            //Пусть максимум будет 10 пакетов, иначе - БАН(не делаем пинг)
            //А то слишком долго ждать будет пользователь
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Здесь у нас будет вывод пинга(скорее всего придется парсить(мб и нет)) из файла(otv.txt)
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //Здесь ясно: пользователь написал ip - даём ему адрес, и наоборот
            //П.С. придётся парсить
            if (nsaddressname.Text == "")
            {
                //Даём пользователю адрес
            }
            else
            {
                //Даём пользователю IP
            }
        }
    }
}
