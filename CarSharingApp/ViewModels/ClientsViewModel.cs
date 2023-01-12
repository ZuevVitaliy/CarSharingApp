using CarSharingApp.Models.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.ViewModels
{
    public class ClientsViewModel : EntityWindowViewModelBase
    {

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Client> SelectedClients { get; set; }

        protected override void AddCommand_Execute()
        {
            throw new NotImplementedException();
        }

        protected override void DeleteCommand_Execute()
        {
            throw new NotImplementedException();
        }

        protected override bool DeleteCommand_CanExecute()
        {
            throw new NotImplementedException();
        }

        protected override void EditCommand_Execute()
        {
            throw new NotImplementedException();
        }

        protected override bool EditCommand_CanExecute()
        {
            throw new NotImplementedException();
        }
    }
}
