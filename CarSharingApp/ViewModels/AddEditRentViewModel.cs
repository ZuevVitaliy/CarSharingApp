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
        private Car _selectedCar;
        private Client _selectedClient;
        public ICollection<Car> Cars { get; }
        public ICollection<Client> Clients { get; }
        public AddEditRentViewModel(IAddEditWindow addEditWindow, Rent rent, ICollection<Car> cars, ICollection<Client> clients) : base(addEditWindow)
        {
            _rent = rent;
        }
        
        public Car SelectedCar
        {
            get=>_selectedCar;
            set { 
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
        
        public DateTime StartDate { get; set; }
        public string StartTime { get; set; }
        public DateTime EndDate { get; set; }

        protected override bool SaveCommand_CanExecute()
        {
            return 
                !string.IsNullOrWhiteSpace(StartTime)&&
                !string.IsNullOrWhiteSpace(EndTime) &&
                !string.IsNullOrWhiteSpace(CostPerHour) &&
                StartDate!=default &&
                EndDate!=default &&
                SelectedCar!=null &&
                SelectedClient!=null
        }

        protected override void SaveEntityOperation()
        {
            _rent.Car = SelectedCar;
            _rent.Client = SelectedClient;
            _rent.StartRent= ParseDateAndTimeToDateTime(StartDate,StartTime);
            _rent.EndRent = ParseDateAndTimeToDateTime(EndDate, EndTime);
            double.TryParse(CostPerHour, out var costPerHour);
            _rent.CostPerHour = costPerHour;
        }

        private DateTime ParseDateAndTimeToDateTime(DateTime startDate, string startTime)
        {
            throw new NotImplementedException();
        }
    }
}
