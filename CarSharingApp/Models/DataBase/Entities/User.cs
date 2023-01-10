namespace CarSharingApp.Models.DataBase.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        Administrator,
        Operator
    }
}
