using System;
using System.Security.Authentication;
using System.Windows;
using Reactive.Bindings;
using WpfBase.Domain.Models.Accounts;
using WpfBase.Factory;
using WpfBase.Framework;
using WpfBase.UseCase.UseCases.Accounts;

namespace WpfBase.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            LoadedCommand.Subscribe(_ => LoadAction());

            BtnLoginCommand.Subscribe(x => BtnLoginAction(x));

            BtnCancelCommand.Subscribe(_ => CancelAction());
        }

        public string ErrorMessage { get; set; }

        public M_AccountEntity Account { get; private set; } = new M_AccountEntity();

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnLoginCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnCancelCommand { get; } = new ReactiveCommand();

        public void LoadAction()
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());
            if (accountService.IsNoData())
            {
                OpenMenu();
            }
        }

        public void BtnLoginAction(object view)
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());

            try
            {
                accountService.CheckLogin(Account);
                OpenMenu();
                ((Window)view).Close();
            }
            catch(AuthenticationException ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void CancelAction()
        {
            Application.Current.Shutdown();
        }

        private void OpenMenu()
        {
            var w = new Views.Menu();
            w.Show();
        }
    }
}
