using Prism.Commands;
using Prism.Mvvm;

namespace CarSharingApp.ViewModels
{
    public abstract class EntityWindowViewModelBase : BindableBase
    {
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand =>
                    _addCommand ??= new DelegateCommand(AddCommand_Execute);

        protected abstract void AddCommand_Execute();

        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
                    _editCommand ??= new DelegateCommand(EditCommand_Execute, EditCommand_CanExecute);

        protected abstract void EditCommand_Execute();
        protected abstract bool EditCommand_CanExecute();

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
                            _deleteCommand ??= new DelegateCommand(DeleteCommand_Execute, DeleteCommand_CanExecute);

        protected abstract void DeleteCommand_Execute();
        protected abstract bool DeleteCommand_CanExecute();
    }
}