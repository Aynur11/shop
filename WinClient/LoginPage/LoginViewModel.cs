using System.Windows;

namespace WinClient.LoginPage
{
    public class LoginViewModel
    {
        private RelayCommand loginButtonCmd;

        public RelayCommand LoginButtonCmd
        {
            get
            {
                return loginButtonCmd ??= new RelayCommand(o =>
                {
                    MessageBox.Show($"Login: {((Login)o).UserLogin.Text}, password: {((Login)o).Password.Password}");
                });
            }
        }
    }
}
