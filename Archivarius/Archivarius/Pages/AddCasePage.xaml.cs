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
        public AddCasePage()
        {
            InitializeComponent();
            JudgeComboBox.ItemsSource = DB.entities.Worker.Where(c => c.Post.Name == "Судья").ToList();
            CategoryComboBox.ItemsSource = DB.entities.Category.ToList();
            ArticleComboBox.ItemsSource= DB.entities.Article.ToList();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
