using Reactive.Bindings;
using System;
using System.Windows;
using WpfBase.Framework;

namespace WpfBase.ViewModel
{
    public class MenuViewModel : ViewModelBase
    {
        public MenuViewModel()
        {
            BtnEndCommand.Subscribe(_ => BtnEndAction());
        }

        public ReactiveCommand BtnOpenMstAccountCommand { get; } = new ReactiveCommand();

        public ReactiveCommand BtnEndCommand { get; } = new ReactiveCommand();

        public ReactiveCommand LoadedCommand { get; } = new ReactiveCommand();

        public void BtnEndAction()
        {
            Application.Current.Shutdown();
        }
    }
}
