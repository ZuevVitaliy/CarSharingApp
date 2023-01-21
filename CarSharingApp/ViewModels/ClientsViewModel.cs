using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.ViewModels
{
    public class ClientsViewModel : EntityWindowViewModelBase<Client>
    {
        public ClientsViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var clients = dbContext.Clients;
            Clients = new ObservableCollection<Client>(clients);
        }

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

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients 
        {
            get => _clients;
            set
            {
                _clients = value;
                RaisePropertyChanged();
            }
        }

        public bool HasCanEditOrRemoveClient => SelectedClient != null;

        protected override bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveClient;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveClient;
        }

        /// <inheritdoc/>
        protected override void EditCommand_Execute()
        {
            base.EditCommand_Execute();
            Clients = new ObservableCollection<Client>(Clients);
        }

        protected override Client SelectedItemExtractor()
        {
            return SelectedClient;
        }

        protected override ICollection<Client> EntitiesCollectionExtractor()
        {
            return Clients;
        }

        protected override ICollection<Client> SelectedItemsExtractor()
        {
            return SelectedClients;
        }
    }
}
