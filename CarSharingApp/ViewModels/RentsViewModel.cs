using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RentSharingApp.ViewModels
{
    public class RentsViewModel : EntityWindowViewModelBase<Rent>
    {
        public RentsViewModel()
        {
            var dbContext = new ApplicationDbContext();
            var rents = dbContext.Rents
                .Include(x => x.Car)
                .Include(x => x.Client);
            Rents = new ObservableCollection<Rent>(rents);
        }

        #region Properties

        private ObservableCollection<Rent> _rents;
        public ObservableCollection<Rent> Rents
        {
            get => _rents;
            set
            {
                _rents = value;
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

        #endregion Properties

        protected override bool EditCommand_CanExecute()
        {
            return HasCanEditOrRemoveRent;
        }

        protected override bool DeleteCommand_CanExecute()
        {
            return HasCanEditOrRemoveRent;
        }

        /// <inheritdoc/>
        protected override void EditCommand_Execute()
        {
            base.EditCommand_Execute();
            Rents = new ObservableCollection<Rent>(Rents);
        }

        /// <inheritdoc/>
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
    }
}
