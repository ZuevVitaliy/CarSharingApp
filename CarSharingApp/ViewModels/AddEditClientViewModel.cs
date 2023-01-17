using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using CarSharingApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.ViewModels
{
    public class AddEditClientViewModel : AddEditViewModelBase
    {
        

        public AddEditClientViewModel(AddEditClientWindow addEditWindow, Client client) : base(addEditWindow)
        {
            _client = client;
        }

        private Client _client;
        private string firstName;
        public string FirstName 
        { 
            get => firstName; 
            set
            {
                firstName = value;
            }
        }
        private string lastName;
        public string LastName 
        { 
            get => lastName;
            set
            {
                lastName = value;
            }
        }
        private DateTime birthDate;
        public DateTime BirthDate 
        { 
            get => birthDate;
            set
            {
                birthDate = value;
            }
        }
        private Vip vIP;
        public Vip VIP 
        { 
            get => vIP;
            set
            {
                vIP = value;
            }
        }






        protected override bool SaveCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
        }

        protected override void SaveEntity()
        {
            throw new NotImplementedException();
        }
    }
}
