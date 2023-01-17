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
    internal class AddEditRentViewModel : AddEditViewModelBase
    {
        private readonly Rent _rent;
        private Car selectedCar;

        private Car selectedClient;
        private DateTime startDay;
        private DateTime startTime;
        private DateTime endDay;
        private DateTime endTime;
        private string costPerHour;
        private Status selectedStatus;

        public AddEditRentViewModel(IAddEditWindow addEditWindow, RentSharingApp rent)
                    : base(addEditWindow)
        {
            _rent = rent;
        }
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public ICollection<Car> Cars { get; }
        public ICollection<Client> Clients { get; }
        public Car SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime StartDay
        {
            get => startDay;
            set
            {
                startDay = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime StartTime
        {
            get => startTime;
            set
            {
                startTime = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime EndDay
        {
            get => endDay;
            set
            {
                endDay = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public DateTime EndTime
        {
            get => endTime;
            set
            {
                endTime = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public string CostPerHour
        {
            get => costPerHour;
            set
            {
                costPerHour = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        public Status SelectedStatus
        {
            get => selectedStatus;
            set
            {
                selectedStatus = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        protected override bool SaveCommand_CanExecute()
        {
            throw new NotImplementedException();
        }

        protected override void SaveEntityOperation()
        {
            _rent.Car = SelectedCar;
            _rent.Client = SelectedClient;
            _rent.StartRent = ParseDateAndTimeToDateTime(StartDay, StartTime);
            _rent.EndRent = ParseDateAndTimeToDateTime(EndDay, EndTime);
            double.TryParse(CostPerHour, out var costPerHour);
            _rent.CostPerHour = costPerHour;
            _rent.Status= SelectedStatus;
        }

        private DateTime ParseDateAndTimeToDateTime(DateTime date, DateTime time)
        {
            var hoursMinutes = time.Split(':');
            return new DateTime(
                date.Year,
                date.Month,
                date.Day,
                int.Parse(hoursMinutes[0]),
                int.Parse(hoursMinutes[1]));
        }
    }
}
