﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Models.DataBase.Entities
{
    public class Client : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Vip Vip { get; set; }

        public virtual ICollection<Rent> Rents { get; set; }
    }

    public enum Vip
    {
        Common,
        Vip
    }
}
