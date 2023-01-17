using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels;
using CarSharingApp.Views.Interfaces;
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

namespace CarSharingApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditRentWindow.xaml
    /// </summary>
    public partial class AddEditRentWindow : Window, IAddEditWindow
    {
        public AddEditRentWindow(Rent rent, ICollection<Car> cars, ICollection<Client> clients)
        {
            InitializeComponent();
            _statusComboBox.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();
            DataContext = new AddEditRentViewModel(this, rent);
        }
    }
}
