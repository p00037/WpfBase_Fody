using System;
using WpfBase.Domain.Shared;

namespace WpfBase.Domain.Models.Accounts
{
    public interface IM_AccountRepository : IRepository<M_AccountEntity, Guid>
    {
    }
}
