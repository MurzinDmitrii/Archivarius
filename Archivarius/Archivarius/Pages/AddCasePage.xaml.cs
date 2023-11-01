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
        bool newCase = true;
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
            this.DataContext = newcase;
            newCase = true;
        }
        public AddCasePage(Case newcase)
        {
            InitializeComponent();
            JudgeComboBox.ItemsSource = DB.entities.Worker.Where(c => c.Post.Name == "Судья").ToList();
            CategoryComboBox.ItemsSource = DB.entities.Category.ToList();
            ArticleComboBox.ItemsSource = DB.entities.Article.ToList();
            this.newcase = newcase;
            this.DataContext = newcase;
            var article = newcase.ArticleCase.FirstOrDefault(c => c.CaseNumber == newcase.Number);
            ArticleComboBox.DataContext = article;
            ArticleComboBox.SelectedItem = article.Article;
            newCase = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(newcase.Date > DateTime.Now.Date)
                {
                    throw new InvalidOperationException("Date is future");
                }
                if (newCase)
                {
                    DB.entities.Case.Add(newcase);

                }
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
                if (newCase)
                    DB.entities.AddAct(newcase.CategoryID, newcase.Number, newcase.Date, 1, DateTime.Now);
                NavigationService.Navigate(new AddCase2PartPage(newcase));
            }
            catch
            {
                MessageBox.Show
                    ("Проверьте правильность внесенных данных!","Ошибка!",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
