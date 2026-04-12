using Microsoft.EntityFrameworkCore;
using Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Models;

namespace Secure_User_Authentication_System_using_ASP.NET_Core_MVC.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
