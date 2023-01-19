using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Models.DataBase.Entities
{
    public class Car : Entity
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string GovNumber { get; set; }

        [NotMapped]
        public string FullName => $"{Mark} {Model} {GovNumber}";


        public virtual ICollection<Rent> Rents { get; set; }
    }
}
