using System.ComponentModel.DataAnnotations;

namespace ASP_Project.ViewModels
{
    public class MessageVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string YourMessage { get; set; }
    }
}
