﻿using CarSharingApp.Models.DataBase.Entities;
using CarSharingApp.Views;
using CarSharingApp.Views.Interfaces;
using System;
using System.Text;

namespace CarSharingApp.Helpers.Window
{
    public class AddEditWindowFactory
    {
        public IAddEditWindow CreateAddEditWindow<TEntity>(TEntity entity) where TEntity : Entity
        {
            var type = typeof(TEntity);
            switch (type.Name)
            {
                case nameof(Car):
                    return new AddEditCarWindow(entity as Car);
                default:
                    throw new ArgumentException(
                        $@"Класс ""{type.Name}"" не определён для фабрики окон создания/редактирования");
            }

        }
    }
}