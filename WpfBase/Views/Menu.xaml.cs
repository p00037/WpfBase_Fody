using WpfBase.ViewModel;
using WpfControlLibrary.CustomContorol;

namespace WpfBase.Views
{
    /// <summary>
    /// Menu.xaml の相互作用ロジック
    /// </summary>
    public partial class Menu : WindowBase
    {
        private MenuViewModel viewModel = new MenuViewModel();

        public Menu()
        {
            InitializeComponent();

            DataContext = this.viewModel;
        }
    }
}
