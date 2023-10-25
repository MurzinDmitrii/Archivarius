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
            Load();
        }
        public AllCasePage()
        {
            InitializeComponent();
            Load();
        }

        //Печать акта о приеме
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Case selectedItem = menu.DataContext as Case;
            NavigationService.Navigate(new AllActPage(selectedItem));
        }
        //выдача/сдача
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Case selectedItem = menu.DataContext as Case;
            
        }
        //изменение
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
        private void Load()
        {
            var CaseList = DB.entities.Case.ToList();
            foreach (var item in CaseList)
            {
                if (item.Act.Count() % 2 == 1)
                {
                    item.BackColor = "White";
                }
                else
                {
                    item.BackColor = "#DDDDDD";
                }
            }
            CaseListView.ItemsSource = CaseList;
        }
    }
}
