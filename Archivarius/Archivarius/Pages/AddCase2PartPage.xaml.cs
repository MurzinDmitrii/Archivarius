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
    /// Логика взаимодействия для AddCase2PartPage.xaml
    /// </summary>
    public partial class AddCase2PartPage : Page
    {
        Case newcase;
        public AddCase2PartPage(Case newcase)
        {
            InitializeComponent();
            this.newcase = newcase;
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Успешно!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new AllCasePage());
        }
        //Добавить истцов
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddParticipantsPage(newcase, true));
        }
        //Добавить ответчиков
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddParticipantsPage(newcase, false));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            try
            {
                var ApplicantList = DB.entities.Applicant.Where(c => c.Case.Number == newcase.Number).ToList();
                ApplicantListView.ItemsSource = ApplicantList;
                var RespondersList = DB.entities.Responder.Where(c => c.Case.Number == newcase.Number).ToList();
                ResponderListView.ItemsSource = RespondersList;
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Потеряно соединение с сервером!",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
