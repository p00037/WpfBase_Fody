using WpfBase.Infrastructure.Contexts;
using WpfBase.Infrastructure.Repository;
using WpfBase.Infrastructure;

namespace WpfBase.UseCase.UseCases.Accounts
{
    public class AccountUseCaseFactory
    {
        public static AccountUseCase Create(WpfBaseContext context)
        {
            var unitOfWork = new UnitOfWork(context);
            var m_AccountRepository = new M_AccountRepository(context);
            return new AccountUseCase(unitOfWork,m_AccountRepository);
        }
    }
}
