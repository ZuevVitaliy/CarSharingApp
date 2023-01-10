using CarSharingApp.Models.DataBase.Entities;
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
    public class AddEditCarViewModel : BindableBase
    {
        private readonly AddEditCarWindow _window;
        private Car _car;

        public AddEditCarViewModel(AddEditCarWindow window, Car car)
        {
            _window = window;
            _car = car;
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

        private DelegateCommand _saveCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ??= new DelegateCommand(SaveCommand_Execute, SaveCommand_CanExecute);

        private void SaveCommand_Execute()
        {
            _car.Mark = Mark;
            _car.Model = Model;
            _car.GovNumber = GovNumber;
            _car.Id  = Guid.Empty.Equals(_car.Id) ? Guid.NewGuid() : _car.Id;
            _window.DialogResult = true;
            _window.Close();
        }

        private bool SaveCommand_CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Mark)
                && !string.IsNullOrWhiteSpace(Model)
                && !string.IsNullOrWhiteSpace(GovNumber);
        }

        private DelegateCommand _cancelCommand;

        public DelegateCommand CancelCommand =>
            _cancelCommand ??= new DelegateCommand(CancelCommand_Execute);

        private void CancelCommand_Execute()
        {
            _window.DialogResult = false;
            _window.Close();
        }
    }
}
