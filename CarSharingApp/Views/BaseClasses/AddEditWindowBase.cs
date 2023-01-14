using CarSharingApp.Models.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarSharingApp.Views.BaseClasses
{
    public class AddEditWindowBase<TEntity> : Window where TEntity : Entity,new()
    {
        public AddEditWindowBase(TEntity entity)
        {

        }
    }
}
