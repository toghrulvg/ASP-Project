namespace ASP_Project.Models
{
    public class Message : BaseEntity
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string YourMessage { get; set; }
    }
}
