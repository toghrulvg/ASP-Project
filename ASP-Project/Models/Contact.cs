namespace ASP_Project.Models
{
    public class Contact : BaseEntity 
    {
        public string ContactUs { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Number { get; set; }
        public string WorkingTime { get; set; }
    }
}
