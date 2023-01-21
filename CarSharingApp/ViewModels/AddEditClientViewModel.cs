using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using CarSharingApp.Views;
using System;

namespace CarSharingApp.ViewModels
{
    public class AddEditClientViewModel : AddEditViewModelBase
    {
        private Client _client;

        public AddEditClientViewModel(
            AddEditClientWindow addEditWindow,
            Client client
            )
            : base(addEditWindow)
        {
            _client = client;
            FirstName = client.FirstName;
            LastName = client.LastName;
            BirthDate = client.BirthDate;
            VIP = client.Vip;
        }

        private string _firstName;
        public string FirstName 
        { 
            get => _firstName;
            set 
            {
                _firstName = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }  
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }
        private Vip _vip;
        public Vip VIP
        {
            get => _vip;
            set
            {
                _vip = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        protected override void SaveEntityOperation()
        {
            _client.FirstName = FirstName;
            _client.LastName = LastName;
            _client.BirthDate = BirthDate;
            _client.Vip = VIP;
        }

        protected override bool SaveCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName);
        }

    }
}
