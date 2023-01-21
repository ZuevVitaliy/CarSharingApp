using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSharingApp.Models.DataBase.Entities
{
    public class Rent : Entity
    {
        public Guid CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
        public Guid ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public DateTime StartRent { get; set; }
        public DateTime EndRent { get; set; }
        public double CostPerHour { get; set; }
        public Status Status { get; set; }

        [NotMapped]
        public double TotalCost => (EndRent - StartRent).TotalMinutes / 60 * CostPerHour;
    }

    public enum Status
    {
        [Description("В наличии")]
        InStock,
        [Description("Арендован")]
        Rented,
        [Description("Просрочен")]
        Overdue
    }
}
