using System.ComponentModel.DataAnnotations;
namespace Advert.Web.Models.Accounts
{
    public class signup
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(6,ErrorMessage ="Password should be minimum 6 character")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(6, ErrorMessage = "Password and confirm password should match")]
        public string ConfirmPassword { get; set; }
    }
}
