using System.Windows;
using System.Windows.Controls;
using WpfBase.Common;
using WpfBase.Views;

namespace WpfBase.UserControls
{
    /// <summary>
    /// CustomMunu.xaml の相互作用ロジック
    /// </summary>
    public partial class CustomMenu : UserControl
    {
        public static readonly DependencyProperty ThisWindowProperty =
        DependencyProperty.Register("ThisWindow",
                                    typeof(object),
                                    typeof(CustomMenu),
                                    new FrameworkPropertyMetadata("Window", new PropertyChangedCallback(OnThisWindowChanged)));

        public CustomMenu()
        {
            InitializeComponent();
        }

        // 2. CLI用プロパティを提供するラッパー
        public Window ThisWindow
        {
            get { return (Window)GetValue(ThisWindowProperty); }
            set { SetValue(ThisWindowProperty, value); }
        }

        private static void OnThisWindowChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
        }

        private void MenuItemStartupScreen_Click(object sender, RoutedEventArgs e)
        {
            OpenMenuEvent();
        }

        private void MenuItemMstAccount_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenMstAccountEvent();
        }

        private void MenuItemClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenMstAccountEvent()
        {
            var w = new MstAccount();
            w.Show();

            ThisWindow.Close();
        }

        private void OpenMenuEvent()
        {
            var w = new Views.Menu();
            w.Show();

            ThisWindow.Close();
        }
    }
}
