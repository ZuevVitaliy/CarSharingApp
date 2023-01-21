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
            StartDate = rent.StartRent==default?
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day):
                new DateTime(rent.StartRent.Year, rent.StartRent.Month, rent.StartRent.Day);
            EndDate = rent.EndRent == default ?
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) :
                new DateTime(rent.EndRent.Year, rent.EndRent.Month, rent.EndRent.Day);
            StartTime = rent.StartRent==default?
                $"{DateTime.Now.Hour}:{DateTime.Now.Minute}":
                $"{rent.StartRent.Hour}:{rent.StartRent.Minute}";
            EndTime = rent.StartRent == default ?
                $"{DateTime.Now.Hour}:{DateTime.Now.Minute}" :
                $"{rent.EndRent.Hour}:{rent.EndRent.Minute}";
            CostPerHour = rent.CostPerHour.ToString();
            var dbContext = new ApplicationDbContext();
            Cars = dbContext.Cars.ToList();
            Clients = dbContext.Clients.ToList();

            SelectedCar = Cars.FirstOrDefault(car => car.Id == rent.CarId);
            SelectedClient = Clients.FirstOrDefault(client => client.Id == rent.ClientId);
            SelectedStatus = rent.Status;
            CostPerHour = rent.CostPerHour.ToString();

            var now = DateTime.Now;

            var start = rent.StartRent;
            StartDate = start == default ?
                new DateTime(now.Year, now.Month, now.Day) :
                new DateTime(start.Year, start.Month, start.Day);
            StartTime = start == default ?
                $"{now.Hour}:{now.Minute}" :
                $"{start.Hour}:{start.Minute}";

            var end = rent.EndRent;
            EndDate = start == default ?
                new DateTime(now.Year, now.Month, now.Day) :
                new DateTime(end.Year, end.Month, end.Day);
            EndTime = start == default ?
                $"{now.Hour}:{now.Minute}" : 
                $"{end.Hour}:{end.Minute}";
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
            _rent.CarId = SelectedCar.Id;
            _rent.ClientId = SelectedClient.Id;
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
