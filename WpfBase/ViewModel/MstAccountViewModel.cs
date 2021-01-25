using Reactive.Bindings;
using System.Collections.ObjectModel;
using WpfBase.Common;
using WpfBase.Domain.Models.Accounts;
using WpfBase.Factory;
using WpfBase.Framework;
using WpfBase.UseCase.UseCases.Accounts;

namespace WpfBase.ViewModel
{
    public class MstAccountViewModel : MasterViewModelBase<M_AccountEntity>
    {
        public MstAccountViewModel()
        {
            BtnTestCommand.Subscribe(() => TestAction());
        }

        public MstAccountSearchEntity SearchOptionEntity { get; set; } = new MstAccountSearchEntity();

        public ReactiveCommand BtnTestCommand { get; } = new ReactiveCommand();

        protected override void Load()
        {
        }

        public void TestAction()
        {
            this.EditData.LoginId = "0000";
            this.EditData.Password = "9999";
            SearchResultEntitys.Add(new M_AccountEntity() { LoginId = "YYYY" });
            SearchResultEntitys[0].LoginId = "XXXXX";
            SearchResultEntitys.Remove(SearchResultEntitys[1]);
        }

        protected override void SetSearchResultEntitys()
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());
            this.SearchResultEntitys = new ObservableCollection<M_AccountEntity>(accountService.GetList(SearchOptionEntity));
        }

        protected override void Save()
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());
            if (EditMode == ComEnum.EnmEditMode.Insert)
            {
                accountService.Register(this.EditData);
            }
            else
            {
                accountService.Update(this.EditData);
            }
        }

        protected override void Delete()
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());
            accountService.Delete(this.EditData);
        }

        protected override void SetEditDataWhenNew()
        {
            this.EditData = new M_AccountEntity();
        }

        protected override void SetEditDataWhenUpdate(M_AccountEntity selectEntity)
        {
            var accountService = AccountUseCaseFactory.Create(WpfBaseContextFactory.Create());
            this.EditData = accountService.Get(selectEntity.Id);
        }
    }
}
