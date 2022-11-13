using System.ComponentModel.DataAnnotations;

namespace ASP_Project.ViewModels.AccountViewModels
{
    public class LoginVM
    {
        [Required]
        public string EmailOrUsername { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
