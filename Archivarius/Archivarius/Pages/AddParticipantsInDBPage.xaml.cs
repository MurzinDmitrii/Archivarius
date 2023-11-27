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
    /// Логика взаимодействия для AddParticipantsInDBPage.xaml
    /// </summary>
    public partial class AddParticipantsInDBPage : Page
    {
        Participants participants = new Participants();
        public AddParticipantsInDBPage()
        {
            InitializeComponent();
            this.DataContext = participants;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.entities.Participants.Add(participants);
                DB.entities.SaveChanges();
                NavigationService.GoBack();
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Потеряно соединение с сервером!",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Проверьте чтобы фамилия и имя были заполнены!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PhoneBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
