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
    /// Логика взаимодействия для AllActPage.xaml
    /// </summary>
    public partial class AllActPage : Page
    {
        Case innercase;
        public AllActPage(Case innercase)
        {
            InitializeComponent();
            this.innercase = innercase;
            var TypeList = DB.entities.Type.ToList();
            TypeComboBox.Items.Add(new Model.Type() { Name = "Все" });
            foreach (var item in TypeList)
            {
                TypeComboBox.Items.Add(item);
            }
            TypeComboBox.SelectedIndex = 0;
            Load();
        }

        private void Load()
        {
            
            var ActList = innercase.Act.OrderByDescending(c => c.Date).ToList();
            if(TypeComboBox.SelectedIndex != 0)
            {
                ActList = ActList.Where(c => c.Type ==  TypeComboBox.SelectedItem).ToList();
            }
            if (!string.IsNullOrEmpty(SearchDate.SelectedDate.ToString()))
            {
                DateTime time = SearchDate.SelectedDate??DateTime.Now;
                ActList = ActList.Where
                    (c => c.Date.ToShortDateString() == time.ToShortDateString()).ToList();
            }
            ActListView.ItemsSource = ActList;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            Act act = menuItem.DataContext as Act;
            try
            {
                PrintAct.Print(act);
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SearchDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }
    }
}
