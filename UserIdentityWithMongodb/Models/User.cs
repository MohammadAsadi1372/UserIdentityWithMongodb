using System.ComponentModel.DataAnnotations;

namespace UserIdentityWithMongodb.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="ایمیل نا معتبر")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}
