using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using CarSharingApp.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.ViewModels
{
    public class AddEditRentViewModel : AddEditViewModelBase
    {
        private readonly Rent _rent;
        {
            _rent = rent;
        }

        public IReadOnlyCollection<Car> Cars { get; }
        public IReadOnlyCollection<Client> Clients { get; }

        private Car _selectedCar;
        public Car SelectedCar
        {
            get => _selectedCar;
            set
            {
                _selectedCar = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string CostPerHour
        {
            get => _costPerHour;
            set
            {
                _costPerHour = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public Status SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        protected override bool SaveCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(StartTime) &&
                !string.IsNullOrWhiteSpace(EndTime) &&
                !string.IsNullOrWhiteSpace(CostPerHour) &&
                StartDate != default &&
                EndDate != default &&
                SelectedCar != null &&
                SelectedClient != null;
        }

        protected override void SaveEntityOperation()
        {
            _rent.Car = SelectedCar;
            _rent.Client = SelectedClient;
            _rent.StartRent = ParseDateAndTimeToDateTime(StartDate, StartTime);
            double.TryParse(CostPerHour, out var costPerHour);
            _rent.CostPerHour = costPerHour;
            _rent.Status = SelectedStatus;
        }

        {
        }
    }
}
