using Microsoft.EntityFrameworkCore;
using WpfBase.Domain.Models.Accounts;

namespace WpfBase.Infrastructure.Contexts
{
    public class WpfBaseContext : DbContext
    {
        public WpfBaseContext(DbContextOptions<WpfBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M_AccountEntity>().ToTable("M_Account");
        }
    }
}
