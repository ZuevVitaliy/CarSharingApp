using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.ViewModels.BaseClasses;
using CarSharingApp.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.ViewModels
{
    public class AddEditCarViewModel : AddEditViewModelBase
    {
        private Rent _car;

        public AddEditCarViewModel(AddEditCarWindow window, Rent car) 
            : base(window)
        {
            Mark = car.Mark;
            Model = car.Model;
            GovNumber = car.GovNumber;
        }

        private string _mark;
        public string Mark
        { 
            get => _mark;
            set
            {
                _mark = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string _model;
        public string Model
        { 
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private string _govNumber;
        public string GovNumber 
        { 
            get => _govNumber;
            set
            {
                _govNumber = value;
                RaisePropertyChanged();
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        protected override void SaveEntityOperation()
        {
            _car.Mark = Mark;
            _car.Model = Model;
            _car.GovNumber = GovNumber;
            _car.Id = Guid.Empty.Equals(_car.Id) ? Guid.NewGuid() : _car.Id;
        }

        protected override bool SaveCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Mark)
                && !string.IsNullOrWhiteSpace(Model)
                && !string.IsNullOrWhiteSpace(GovNumber);
        }

    }
}
