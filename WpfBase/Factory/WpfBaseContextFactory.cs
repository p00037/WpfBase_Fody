using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WpfBase.Infrastructure.Contexts;

namespace WpfBase.Factory
{
    public class WpfBaseContextFactory
    {
        public static WpfBaseContext Create()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var builder = new DbContextOptionsBuilder<WpfBaseContext>();
            builder.UseSqlServer(connectionString);
            return new WpfBaseContext(builder.Options);
         }
    }
}
