using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Models.Extensions;
using CarSharingApp.Views;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarSharingApp.ViewModels
{
    public class CarsViewModel : BindableBase
    {
        public CarsViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var cars = dbContext.Cars;
            Cars = new ObservableCollection<Car>(cars);
        }

        private Role _role;
        public Role Role
        { 
            get => _role; 
            set
            {
                _role = value;
                RaisePropertyChanged(nameof(HasUserAdminOptions));
            }
        }

        #region Properties

        private ObservableCollection<Car> _cars;
        public ObservableCollection<Car> Cars
        {
            get => _cars;
            set
            {
                _cars = value;
                RaisePropertyChanged();
            }
        }

        private Car _selectedCar;

        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCars.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<Car> _selectedCars;
        public ObservableCollection<Car> SelectedCars
        {
            get => _selectedCars;
            set
            {
                _selectedCars = value;
            }
        }

        private bool HasCanEditOrRemoveCar => SelectedCar != null;
        public bool HasUserAdminOptions => Role == Role.Administrator;

        #endregion Properties

        #region Commands

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand =>
                    _addCommand ??= new DelegateCommand(AddCommand_Execute);

        private void AddCommand_Execute()
        {
            var car = new Car();
            var addWindow = new AddEditCarWindow(car);
            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        dbContext.Cars.Add(car);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cars.Add(car);
            }
        }

        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
                    _editCommand ??= new DelegateCommand(EditCommand_Execute, EditCommand_CanExecute);

        private void EditCommand_Execute()
        {
            var car = SelectedCar;
            var addWindow = new AddEditCarWindow(car);
            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        dbContext.Entry(car).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Cars = new ObservableCollection<Car>(Cars);
            }
        }

        private bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveCar;
        }

        private DelegateCommand _deleteCommand;

        public DelegateCommand DeleteCars =>
                            _deleteCommand ??= new DelegateCommand(DeleteCommand_Execute, DeleteCommand_CanExecute);

        private void DeleteCommand_Execute()
        {
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Cars.RemoveRange(SelectedCars);
                    dbContext.SaveChanges();
                }
                Cars.RemoveRange(SelectedCars);
                SelectedCar = null;
                SelectedCars = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveCar;
        }

        #endregion Commands
    }
}
