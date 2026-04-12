using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
