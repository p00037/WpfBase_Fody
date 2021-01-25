using EntityFrameworkBase;
using WpfBase.Infrastructure.Contexts;

namespace WpfBase.Infrastructure
{
    public class UnitOfWork : UnitOfWork<WpfBaseContext>
    {
        public UnitOfWork(WpfBaseContext context) : base(context) { }
    }
}
