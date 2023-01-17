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
    public class ClientsViewModel : EntityWindowViewModelBase<Rent>
    {
        public ClientsViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var clients = dbContext.Clients;
            Clients = new ObservableCollection<Rent>(clients);
        }

        private Rent _selectedClient;

        public Rent SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Rent> SelectedClients { get; set; }

        public ObservableCollection<Rent> Clients { get; set; }

        public bool HasCanEditOrRemoveClient => SelectedClient != null;

        protected override bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveClient;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveClient;
        }

        protected override Rent SelectedItemExtractor()
        {
            return SelectedClient;
        }

        protected override ObservableCollection<Rent> EntitiesCollectionExtractor()
        {
            return Clients;
        }

        protected override ObservableCollection<Rent> SelectedItemsExtractor()
        {
            return SelectedClients;
        }

        
        
       
    }
}
