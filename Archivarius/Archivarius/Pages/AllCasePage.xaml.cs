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
            Classes.Print.PrintInnerDocument.Print(selectedItem);
        }
    }
}
