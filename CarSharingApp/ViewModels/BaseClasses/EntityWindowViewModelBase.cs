using CarSharingApp.Helpers;
using CarSharingApp.Models.DataBase;
using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Models.Extensions;
using CarSharingApp.Views.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CarSharingApp.ViewModels
{
    public abstract class EntityWindowViewModelBase<TEntity> : BindableBase where TEntity : Entity , new()
    {
        private readonly AddEditWindowFactory _addEditWindowFactory;
        public EntityWindowViewModelBase()
        {
            _addEditWindowFactory = new AddEditWindowFactory();
        }


        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand =>
                    _addCommand ??= new DelegateCommand(AddCommand_Execute);


        protected virtual void AddCommand_Execute()
        {
            var addingEntity = new TEntity();
            var addWindow = _addEditWindowFactory.CreateAddEditWindow(addingEntity);
            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        DbSet<TEntity> dbset = dbContext.Set<TEntity>();
                        dbset.Add(addingEntity);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                var Collection = EntitiesCollectionExtractor();
                Collection.Add(addingEntity);
            }
        }

        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
                    _editCommand ??= new DelegateCommand(EditCommand_Execute, EditCommand_CanExecute);

        protected virtual void EditCommand_Execute()
        {
            var editingEntity = SelectedItemsExtractor();
            var addWindow = _addEditWindowFactory.CreateAddEditWindow(editingEntity);
            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    using (var dbContext = new ApplicationDbContext())
                    {
                        dbContext.Entry(editingEntity).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                var collection = EntitiesCollectionExtractor();
                collection = new ObservableCollection<TEntity>(collection);
            }
        }
        protected abstract bool EditCommand_CanExecute();

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
                            _deleteCommand ??= new DelegateCommand(DeleteCommand_Execute, DeleteCommand_CanExecute);

        protected virtual void DeleteCommand_Execute()
        {
            ObservableCollection<TEntity> selectedItems = EntitiesCollectionExtractor();
            try
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    var dbSet = dbContext.Set<TEntity>();
                    dbSet.RemoveRange(selectedItems);
                    dbContext.SaveChanges();
                }
                ObservableCollection<TEntity> itemsCollection = EntitiesCollectionExtractor();
                itemsCollection.RemoveRange(selectedItems);
                itemsCollection = null;
                selectedItems = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected abstract bool DeleteCommand_CanExecute();

        protected abstract TEntity SelectedItemExtractor();
        protected abstract ObservableCollection<TEntity> EntitiesCollectionExtractor();
        protected abstract ObservableCollection<TEntity> SelectedItemsExtractor();
    }
}