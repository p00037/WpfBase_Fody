using EntityFrameworkBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfBase.Infrastructure.Contexts;

namespace WpfBase.Infrastructure.Framework
{
    public class RepositoryBase<TEntity, TKey> : RepositoryBase<WpfBaseContext, TEntity, TKey> where TEntity : class
    {
        public RepositoryBase(WpfBaseContext context) : base(context) { }
    }
}
