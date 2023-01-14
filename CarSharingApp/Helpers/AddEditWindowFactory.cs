using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Views;
using CarSharingApp.Views.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Helpers
{
    public class AddEditWindowFactory
    {
        public AddEditCarWindow CreateAddEditWindow<TEntity>(TEntity entity) where TEntity : Entity
        {
            var type = typeof(TEntity);
            switch (type.Name)
            {
                case nameof(Car):
                    return new AddEditCarWindow(entity as Car);
                default:
                    throw new ArgumentException($@"Класс ""{type.Name}"" не определен для фабрики окон создания/редактирования");
            }
        }
    }
}
