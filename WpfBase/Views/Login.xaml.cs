using WpfBase.ViewModel;
using WpfControlLibrary.CustomContorol;

namespace WpfBase.Views
{
    /// <summary>
    /// Login.xaml の相互作用ロジック
    /// </summary>
    public partial class Login : WindowBase
    {
        private LoginViewModel viewModel = new LoginViewModel();

        public Login()
        {
            InitializeComponent();

            DataContext = this.viewModel;
        }
    }
}
