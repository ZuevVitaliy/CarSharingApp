using CarSharingApp.Models.DataBase.Entities;

namespace CarSharingApp.Models.Dtos
{
    public class RentDto : Rent
    {
        public double TotalCost => (EndRent - StartRent).TotalMinutes / 60 * CostPerHour;
    }
}
