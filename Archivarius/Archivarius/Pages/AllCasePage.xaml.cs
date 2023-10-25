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
    /// Логика взаимодействия для AllCasePage.xaml
    /// </summary>
    public partial class AllCasePage : Page
    {
        public AllCasePage(Worker worker)
        {
            InitializeComponent();
            Properties.Settings.Default.FullName = "Здравствуйте, " + worker.Name + " " +
                (worker.Patronimyc ?? "") + "!";
            CaseListView.ItemsSource = DB.entities.Case.ToList();
        }
        public AllCasePage()
        {
            InitializeComponent();
            CaseListView.ItemsSource = DB.entities.Case.ToList();
        }

        //Печать акта о приеме
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Case selectedItem = menu.DataContext as Case;
            try
            {
                Classes.Print.PrintAct.Print(selectedItem, true);
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
    }
}
