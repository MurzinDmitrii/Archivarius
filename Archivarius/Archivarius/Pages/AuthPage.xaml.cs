using Archivarius.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Archivarius.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            Worker worker = DB.entities.Worker.FirstOrDefault(c => c.Login == LoginBox.Text);
            if (worker != null)
            {
                if (Cryptography.Cryptography.VerifyHashedPassword
                   (worker.EnterData.Password.ToString(), PasswordBox.Password))
                {
                    Properties.Settings.Default.AfterAuthPanelVisible = "Visible";
                    NavigationService.Navigate(new AllCasePage(worker));
                }
                else
                {
                    MessageBox.Show("Вам отказано в доступе! Неверный пароль!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show("Вам отказано в доступе! Неверный логин!","Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
