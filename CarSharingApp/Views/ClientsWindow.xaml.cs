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
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {

        private readonly ClientsViewModel _clientsViewModel;

        public ClientsWindow()
        {
            InitializeComponent();
            _clientsViewModel = new ClientsViewModel();
            DataContext = _clientsViewModel;
        }

        private void ClientsDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedClients = ((DataGrid)sender).SelectedItems.Cast<Client>();
            _clientsViewModel.SelectedClients = new ObservableCollection<Client>(selectedClients);
        }
    }
}
