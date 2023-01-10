using CarSharingApp.ViewModels;
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
using CarSharingApp.Models.DataBase.Entities;

namespace CarSharingApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditCarWindow.xaml
    /// </summary>
    public partial class AddEditCarWindow : Window
    {
        public AddEditCarWindow(Car car)
        {
            InitializeComponent();
            DataContext = new AddEditCarViewModel(this, car);
        }
    }
}
