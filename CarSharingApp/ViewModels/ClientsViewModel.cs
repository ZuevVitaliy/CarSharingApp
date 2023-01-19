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

        public ObservableCollection<Client> Clients { get; set; }

        public bool HasCanEditOrRemoveClient => SelectedClient != null;

        protected override bool EditCommand_CanExecute()
        {
            //TODO: костыль для запуска окна. Позже изменить логику
            return HasCanEditOrRemoveClient;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            //TODO: костыль для запуска окна. Позже изменить логику
            return HasCanEditOrRemoveClient;
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
