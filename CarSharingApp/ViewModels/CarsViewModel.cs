﻿using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Models.Extensions;
using CarSharingApp.ViewModels.BaseClasses;
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
    public class CarsViewModel : EntityWindowViewModelBase<Car>
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
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Car> SelectedCars { get; set; }

        private bool HasCanEditOrRemoveCar => SelectedCar != null;
        public bool HasUserAdminOptions => Role == Role.Administrator;

        #endregion Properties
        #region Commands

        protected override bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveCar;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveCar;
        }

        private DelegateCommand _openClientsWindowCommand;
        public DelegateCommand OpenClientsWindowCommand =>
            _openClientsWindowCommand ??= new DelegateCommand(OpenClientsWindowCommand_Execute);

        private void OpenClientsWindowCommand_Execute()
        {
            var clientsWindow = new ClientsWindow();
            clientsWindow.Show();
        }

        private DelegateCommand _openRentsWindowCommand;
        public DelegateCommand OpenRentsWindowCommand =>
            _openRentsWindowCommand ??= new DelegateCommand(OpenRentsWindowCommand_Execute);

        private void OpenRentsWindowCommand_Execute()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        protected override Car SelectedItemExtractor()
        {
            return SelectedCar;
        }

        /// <inheritdoc/>
        protected override ObservableCollection<Car> EntitiesCollectionExtractor()
        {
            return Cars;
        }

        /// <inheritdoc/>
        protected override ObservableCollection<Car> SelectedItemsExtractor()
        {
            return SelectedCars;
        }

        #endregion Commands
    }
}
