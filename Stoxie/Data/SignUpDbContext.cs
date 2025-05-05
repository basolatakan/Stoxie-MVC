using Microsoft.EntityFrameworkCore;
using Stoxie.Models;

namespace Stoxie.Data
{
    public class SignUpDbContext : DbContext
    {
        public SignUpDbContext(DbContextOptions<SignUpDbContext> options) : base(options) { }

        public DbSet<SignUp> SignUps { get; set; }  //Bu, SQL Server’daki SignUps tablosunun C# karşılığıdır.

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
