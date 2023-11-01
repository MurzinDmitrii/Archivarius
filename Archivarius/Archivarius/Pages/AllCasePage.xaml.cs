using Archivarius.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            var JudgeList = DB.entities.Worker.Where(c => c.Post.Name == "Судья");
            SearchComboBox.Items.Add(new Model.Worker() { FirstName = "Все"});
            foreach (var item in JudgeList)
            {
                SearchComboBox.Items.Add(item);
            }
            SearchComboBox.SelectedIndex = 0;
            Load();
        }
        public AllCasePage()
        {
            InitializeComponent();
            var JudgeList = DB.entities.Worker.Where(c => c.Post.Name == "Судья");
            SearchComboBox.Items.Add(new Model.Worker() { FirstName = "Все" });
            foreach (var item in JudgeList)
            {
                SearchComboBox.Items.Add(item);
            }
            SearchComboBox.SelectedIndex = 0;
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
            if(selectedItem.ButtonType  == "Выдать")
            {
                DB.entities.AddAct(selectedItem.CategoryID, selectedItem.Number, selectedItem.Date, 2, DateTime.Now);
            }
            else
            {
                DB.entities.AddAct(selectedItem.CategoryID, selectedItem.Number, selectedItem.Date, 1, DateTime.Now);
            }
            DB.entities.SaveChanges();
            Load();
        }
        //изменение
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;
            Case selectedItem = menu.DataContext as Case;
            NavigationService.Navigate(new AddCasePage(selectedItem));
        }
        private void Load()
        {
            DB.entities = new ArhivariusEntities1();
            var CaseList = DB.entities.Case.ToList();
            if (SearchComboBox.SelectedIndex != 0)
            {
                CaseList = CaseList.Where(c => c.Worker == SearchComboBox.SelectedItem).ToList();
            }
            if (!string.IsNullOrEmpty(SearchDatePicker.SelectedDate.ToString()))
            {
                DateTime time = SearchDatePicker.SelectedDate ?? DateTime.Now;
                CaseList = CaseList.Where
                    (c => c.Date.ToShortDateString() == time.ToShortDateString()).ToList();
            }
            if (!string.IsNullOrEmpty(SearchBox.Text))
            {
                CaseList = CaseList.Where
                    (c => c.CaseFullNumber.Contains(SearchBox.Text)).ToList();
            }
            foreach (var item in CaseList)
            {
                if (item.Act.Count() % 2 == 1)
                {
                    item.ButtonType = "Выдать";
                    item.BackColor = "White";
                }
                else
                {
                    item.ButtonType = "Принять";
                    item.BackColor = "#DDDDDD";
                }
            }
            CaseListView.ItemsSource = CaseList;
            if (CaseList.Count == 0)
            {
                MessageBox.Show("По результатам поиска не найдено подходящих вариантов",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Load();
        }

        private void SearchDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Load();
        }
    }
}
