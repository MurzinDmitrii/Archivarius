using Archivarius.Classes.Print;
using Archivarius.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AllQueryPage.xaml
    /// </summary>
    public partial class AllQueryPage : Page
    {
        public AllQueryPage()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            try
            {
                var QueryList = DB.entities.Query.ToList();
                if (!string.IsNullOrEmpty(SearchDate.SelectedDate.ToString()))
                {
                    DateTime time = SearchDate.SelectedDate ?? DateTime.Now;
                    QueryList = QueryList.Where
                        (c => c.Date.ToShortDateString() == time.ToShortDateString()).ToList();
                }
                if (!string.IsNullOrEmpty(SearchBox.Text))
                {
                    QueryList = QueryList.Where
                        (c => c.Case.CaseFullNumber.Contains(SearchBox.Text)).ToList();
                }
                if (QueryList.Count == 0)
                {
                    MessageBox.Show("По результатам поиска не найдено подходящих вариантов",
                        "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                QueryListView.ItemsSource = QueryList;
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                MessageBox.Show("Потеряно соединение с сервером!",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Query query = menuItem.DataContext as Query;
            try
            {
                PrintQuery.Print(query);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Pdf Files|*.pdf";
                openFileDialog.ShowDialog();
                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    File.Delete("InnerPDF.pdf");
                    MessageBox.Show("Пожалуйста, выберите файл!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    SignatureLibrary.Signature.Signed(openFileDialog.FileName);
                    File.Delete("InnerPDF.pdf");
                    MessageBox.Show("Выполнено!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    ("Пожалуйста, проверьте, чтобы выбранный файл не был открыт в другом приложении!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load();
        }

        private void SearchDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddQueryPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
