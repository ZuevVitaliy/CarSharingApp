using CarSharingApp.Models.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Models.Dtos
{
    public class RentDto : Rent
    {
        public double TotalCost => (EndRent - StartRent).TotalMinutes / 60 * CostPerHour;
    }
}
