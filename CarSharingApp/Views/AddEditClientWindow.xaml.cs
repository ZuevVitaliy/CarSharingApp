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
    /// Логика взаимодействия для AddEditClientWindow.xaml
    /// </summary>
    public partial class AddEditClientWindow : Window, IAddEditWindow
    {
        public AddEditClientWindow(Rent client)
        {
            InitializeComponent();
            DataContext = new AddEditClientViewModel(this ,client);
        }
    }
}
