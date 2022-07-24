using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SocialMediaApplication.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Provide Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Provide Password")]
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool isAdmin { get; set; }
        public List<Feed>? Posts { get; set; }

    }
}
