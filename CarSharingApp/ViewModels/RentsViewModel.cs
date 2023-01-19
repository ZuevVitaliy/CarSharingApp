using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Models.Dtos;
using CarSharingApp.ViewModels.BaseClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentSharingApp.ViewModels
{
    public class RentsViewModel : EntityWindowViewModelBase<Rent>
    {
        public RentsViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var rents = dbContext.Rents.Select(x =>
            new RentDto
            {
                Id = x.Id,
                Car = x.Car,
                CarId = x.CarId,
                Client = x.Client,
                ClientId = x.ClientId,
                CostPerHour = x.CostPerHour,
                StartRent = x.StartRent,
                EndRent = x.EndRent,
                Status = x.Status
            });
            Rents = new ObservableCollection<RentDto>(rents);
        }


        public ObservableCollection<RentDto> Rents
        {
            set
            {
                RaisePropertyChanged();
            }
        }

        private Rent _selectedRent;

        public Rent SelectedRent
        {
            get => _selectedRent;
            set
            {
                _selectedRent = value;
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Rent> SelectedRents { get; set; }

        private bool HasCanEditOrRemoveRent => SelectedRent != null;

        protected override bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveRent;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveRent;
        }
        protected override ICollection<Rent> EntitiesCollectionExtractor()
        {
            return (ICollection<Rent>)Rents;
        }

        /// <inheritdoc/>
        protected override Rent SelectedItemExtractor()
        {
            return SelectedRent;
        }

        /// <inheritdoc/>
        protected override ICollection<Rent> SelectedItemsExtractor()
        {
            return SelectedRents;
        }
        #endregion Properties
    }
}
