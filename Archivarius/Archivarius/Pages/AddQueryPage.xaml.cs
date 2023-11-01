﻿using Archivarius.Model;
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
    /// Логика взаимодействия для AddQueryPage.xaml
    /// </summary>
    public partial class AddQueryPage : Page
    {
        public AddQueryPage()
        {
            InitializeComponent();
            var CaseList = DB.entities.Case.ToList();
            CaseComboBox.ItemsSource = CaseList;
            CaseComboBox.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Query query = new Query();
            query.Description = DescBox.Text == "" ? "-" : DescBox.Text;
            query.Case = CaseComboBox.SelectedItem as Case;
            DB.entities.Query.Add(query);
            DB.entities.SaveChanges();
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}