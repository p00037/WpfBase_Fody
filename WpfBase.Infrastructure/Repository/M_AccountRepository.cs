using System;
using System.Collections.Generic;
using System.Linq;
using ExtensionsLibrary;
using WpfBase.Domain.Models.Accounts;
using WpfBase.Infrastructure.Contexts;
using WpfBase.Infrastructure.Framework;

namespace WpfBase.Infrastructure.Repository
{
    public class M_AccountRepository : RepositoryBase<M_AccountEntity, Guid>, IM_AccountRepository
    {
        public M_AccountRepository(WpfBaseContext context) : base(context) { }

        public IEnumerable<M_AccountEntity> GetList(MstAccountSearchEntity searchEntity)
        {
            return GetList(e => e.LoginId.Contains(searchEntity.LoginId.NullToValue(""))).OrderBy(e => e.LoginId).ToList();
        }
    }
}
