using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CarSharingApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        private CarsViewModel _carsViewModel;

        public CarsWindow(string login, Role role)
        {
            InitializeComponent();
            _carsViewModel = new CarsViewModel();
            DataContext = _carsViewModel;
            _carsViewModel.Role = role;
        }

        private void CarsDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCars = ((DataGrid)sender).SelectedItems.Cast<Car>();
            _carsViewModel.SelectedCars = new ObservableCollection<Car>(selectedCars);
        }
    }
}
