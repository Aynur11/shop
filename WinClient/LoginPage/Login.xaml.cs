using System.Windows;
using System.Windows.Controls;

namespace WinClient.LoginPage
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly MainWindow _mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = new LoginViewModel();
        }

        private void RegistrationButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.Frame.Navigate(new Registration());
        }
    }
}
