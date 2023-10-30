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
    /// Логика взаимодействия для AddCasePage.xaml
    /// </summary>
    public partial class AddCasePage : Page
    {
        Case newcase = new Case() 
        { 
            Date = DateTime.Now.Date,
        };
        public AddCasePage()
        {
            InitializeComponent();
            JudgeComboBox.ItemsSource = DB.entities.Worker.Where(c => c.Post.Name == "Судья").ToList();
            CategoryComboBox.ItemsSource = DB.entities.Category.ToList();
            ArticleComboBox.ItemsSource = DB.entities.Article.ToList();
        }
        public AddCasePage(Case newcase)
        {
            InitializeComponent();
            JudgeComboBox.ItemsSource = DB.entities.Worker.Where(c => c.Post.Name == "Судья").ToList();
            CategoryComboBox.ItemsSource = DB.entities.Category.ToList();
            ArticleComboBox.ItemsSource = DB.entities.Article.ToList();
            this.newcase = newcase;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = newcase;
            DB.entities.Case.Add(newcase);
            if (ArticleComboBox.SelectedItem != null)
            {
                ArticleCase articleCase = new ArticleCase()
                {
                    Case = newcase,
                    Article = (ArticleComboBox.SelectedItem as Article)
                };
                DB.entities.ArticleCase.Add(articleCase);
            }
            DB.entities.SaveChanges();
            DB.entities.AddAct(newcase.CategoryID, newcase.Number, newcase.Date, 1, DateTime.Now);
            MessageBox.Show("Выполнено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
