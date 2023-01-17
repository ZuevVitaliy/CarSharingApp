using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Views.Interfaces;
using Prism.Commands;

namespace CarSharingApp.ViewModels.BaseClasses
{
    public abstract class AddEditViewModelBase
    {
        private readonly IAddEditWindow _addEditWindow;
        public AddEditViewModelBase(IAddEditWindow addEditWindow)
        {
            _addEditWindow = addEditWindow;
        }


        private DelegateCommand _saveCommand;

        private DelegateCommand _cancelCommand;
        public DelegateCommand SaveCommand =>
            _saveCommand ??= new DelegateCommand(SaveCommand_Execute, SaveCommand_CanExecute);

        public DelegateCommand CancelCommand =>
            _cancelCommand ??= new DelegateCommand(CancelCommand_Execute);

        protected abstract void SaveEntity();
        protected abstract bool SaveCommand_CanExecute();
        protected void SaveCommand_Execute()
        {
            SaveEntity();
            _addEditWindow.DialogResult = true;

        }
        protected void CancelCommand_Execute()
        {
            _addEditWindow.DialogResult = false;
            _addEditWindow.Close();
        }
    }
}