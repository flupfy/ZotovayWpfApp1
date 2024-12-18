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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        private Hotel _currentHotel = new Hotel();
        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();

            if (selectedHotel != null)
                _currentHotel = selectedHotel;
            
            DataContext = _currentHotel;
            ComboCountries.ItemsSource = Lkhasarunov1Entities.GetContext().Country.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errosrs = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
                errosrs.AppendLine("Укажите название отеля");
            if (_currentHotel.CountOfStars < 1 || _currentHotel.CountOfStars > 5)
                errosrs.AppendLine("Количество звёзд - число от 1 до 5");
            if (_currentHotel.Country == null)
                errosrs.AppendLine("Выберите страну");

            if (errosrs.Length > 0)
            {
                MessageBox.Show(errosrs.ToString());
                return;
            }

            if (_currentHotel.id == 0)
                Lkhasarunov1Entities.GetContext().Hotel.Add(_currentHotel);

            try
            {
                Lkhasarunov1Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
    }
}
