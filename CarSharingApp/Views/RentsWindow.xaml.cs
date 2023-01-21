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
using System.Windows.Shapes;

namespace CarSharingApp.Views
{
    /// <summary>
    /// Логика взаимодействия для RentsWindow.xaml
    /// </summary>
    public partial class RentsWindow : Window
    {
        private readonly RentsViewModel _rentsViewModel;

        public RentsWindow()
        {
            InitializeComponent();
            _rentsViewModel = new RentsViewModel();
            DataContext = _rentsViewModel;
        }

        private void RentsDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRents = ((DataGrid)sender).SelectedItems.Cast<Rent>();
            _rentsViewModel.SelectedRents = new ObservableCollection<Rent>(selectedRents);
        }
    }
}
