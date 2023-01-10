using System;
using System.ComponentModel.DataAnnotations;

namespace CarSharingApp.Models.DataBase.Entities
{
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
