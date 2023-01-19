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
        private Client _client;

        public AddEditClientViewModel(
            AddEditClientWindow addEditWindow,
            Client client
            )
            : base(addEditWindow)
        {
            _client = client;
        }

        public string FirstName 
        { 
            set 
            {
            }  
        }
        public string LastName
        {
            set
            {
            }
        }
        public DateTime BirthDate
        {
            set
            {
            }
        }
        public Vip VIP
        {
            set
            {
            }
        }

        protected override bool SaveCommand_CanExecute()
        {
            throw new NotImplementedException();
        }

        protected override void SaveEntityOperation()
        {
            throw new NotImplementedException();
        }
    }
}
