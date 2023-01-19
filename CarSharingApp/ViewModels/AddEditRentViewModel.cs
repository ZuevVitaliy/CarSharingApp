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

        public AddEditRentViewModel(IAddEditWindow addEditWindow, Rent rent)
            : base(addEditWindow)
        {
            _rent = rent;
            SelectedCar = rent.Car;
            SelectedClient = rent.Client;
            SelectedStatus = rent.Status;
            CostPerHour = rent.CostPerHour.ToString();

            var start = rent.StartRent;
            StartDate = new DateTime(start.Year, start.Month, start.Day);
            StartTime = $"{start.Hour}:{start.Minute}";

            var end = rent.EndRent;
            EndDate = new DateTime(end.Year, end.Month, end.Day);
            EndTime = $"{end.Hour}:{end.Minute}";

            var dbContext = new ApplicationDbContext();
            Cars = dbContext.Cars.ToList();
            Clients = dbContext.Clients.ToList();
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

        private Client _selectedClient;
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

        private DateTime _startDate;
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

        private string _startTime;
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

        private DateTime _endDate;
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

        private string _endTime;
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

        private string _costPerHour;
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

        private Status _selectedStatus;
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


        protected override void SaveEntityOperation()
        {
            _rent.Car = SelectedCar;
            _rent.Client = SelectedClient;
            _rent.StartRent = ParseDateAndTimeToDateTime(StartDate, StartTime);
            _rent.EndRent = ParseDateAndTimeToDateTime(EndDate, EndTime);
            double.TryParse(CostPerHour, out var costPerHour);
            _rent.CostPerHour = costPerHour;
            _rent.Status = SelectedStatus;
        }

        private DateTime ParseDateAndTimeToDateTime(DateTime date, string time)
        {
            var hoursMinutes = time.Split(':');
            return new DateTime(date.Year, date.Month, date.Day,
                int.Parse(hoursMinutes[0]), int.Parse(hoursMinutes[1]), 0);
        }

        protected override bool SaveCommand_CanExecute()
        {
            return
                !string.IsNullOrWhiteSpace(StartTime) &&
                !string.IsNullOrWhiteSpace(EndTime) &&
                !string.IsNullOrWhiteSpace(CostPerHour) &&
                StartDate != default &&
                EndDate != default &&
                SelectedCar != null &&
                SelectedClient != null;
        }
    }
}
