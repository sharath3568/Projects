using Microsoft.AspNetCore.Identity;
using Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Models;

namespace Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Service
{
    public class PasswordService
    {
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<Models.User>();

        public string HashPassword(User user, string password)
        {
            return _hasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string enteredPassword, string storedHash)
        {
            var result = _hasher.VerifyHashedPassword(user, storedHash, enteredPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
