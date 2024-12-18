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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Vxod.xaml
    /// </summary>
    public partial class Vxod : Page
    {
        public Vxod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Tours_Page());
        }
        private bool IsValidadmin(string login, string password)
        {

            return login == "admin" && password == "admin";
        }
        private bool IsValidmanager(string login, string password)
        {
            return login == "manager" && password == "manager";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = TextBoxName.Text;
            string password = PassBox.Password;


            if (IsValidadmin(login, password))
            {
                MessageBox.Show("Добро пожаловать в систему Администратора!");
                Manager.MainFrame.Navigate(new HotelsPage());

            }
            else if (IsValidmanager(login, password))
            {
                MessageBox.Show("Добро пожаловать в систему Менеджера");
                Manager.MainFrame.Navigate(new AddEditPage(null));

            }

            else
            {
                MessageBox.Show("Неправильный пароль или логин.");
            }
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
