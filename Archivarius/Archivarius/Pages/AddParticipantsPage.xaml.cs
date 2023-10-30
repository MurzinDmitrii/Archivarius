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
    /// Логика взаимодействия для AddParticipantsPage.xaml
    /// </summary>
    public partial class AddParticipantsPage : Page
    {
        Case innercase;
        bool type; // true - истец, false - ответчик
        public AddParticipantsPage(Case innercase, bool type)
        {
            InitializeComponent();
            this.innercase = innercase;
            this.type = type;
            ParticipantsComboBox.ItemsSource = DB.entities.Participants.ToList();
            ParticipantsComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddParticipantsInDBPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (type)
            {
                /*DB.entities.AddApplicant((ParticipantsComboBox.SelectedItem as Participants).ID, innercase.Number,
                    innercase.Date, innercase.CategoryID);*/
                Applicant applicant = new Applicant();
                applicant.Case = innercase;
                applicant.Participants = (ParticipantsComboBox.SelectedItem as Participants);
            }
            else
            {
                /*DB.entities.AddResponder((ParticipantsComboBox.SelectedItem as Participants).ID, innercase.Number,
                    innercase.Date, innercase.CategoryID);*/
                Responder responder = new Responder();
                responder.Case = innercase;
                responder.Participants = (ParticipantsComboBox.SelectedItem as Participants);
            }
            DB.entities = new ArhivariusEntities1();
            NavigationService.GoBack();
        }
    }
}
