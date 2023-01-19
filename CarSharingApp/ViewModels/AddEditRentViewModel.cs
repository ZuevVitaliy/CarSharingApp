using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using CarSharingApp.Views.Interfases;
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
        public AddEditRentViewModel(IAddEditWindow addEditWindow, Rent rent,ICollection<Car> cars,ICollection<Client> clients) : base(addEditWindow)
        {
            _rent = rent;
            Cars = cars;
            Client = clients;
        }
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
        public ICollection<Car> Cars
        {
            get;
            set;
        }
        public Client _selectedClient;
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
        public ICollection<Client> Client
        {
            get;
            set;
        }
        public DateTime _startDate;
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
        public string _startTime;
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
        public DateTime _endDate;
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
        public string _endTime;
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
        public string _costPerHour;
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
        public Status _selectedStatus;
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
            _rent.EndRent = ParseDateAndTimeToDateTime(EndDate, StartTime);
            double.TryParse(CostPerHour, out var costPerHour);
            _rent.CostPerHour = costPerHour;
            _rent.Status = SelectedStatus;
        }

        private DateTime ParseDateAndTimeToDateTime(DateTime Date, string Time)
        {
            var hoursMinutes = Time.Split(':');
            return new DateTime(Date.Year, Date.Month, Date.Day, int.Parse(hoursMinutes[0]), int.Parse(hoursMinutes[1]),0);
        }
    }
}
