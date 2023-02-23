namespace Pizza_Project.Models
{
    //This holds user information when it is read from the database
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStaff { get; set; }
    }
}