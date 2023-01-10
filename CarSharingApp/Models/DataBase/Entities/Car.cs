using System;
using System.Collections.Generic;
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

        public virtual ICollection<Rent> Rents { get; set; }
    }
}
