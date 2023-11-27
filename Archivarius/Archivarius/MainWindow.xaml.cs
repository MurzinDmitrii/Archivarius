using Archivarius.Pages;
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

namespace Archivarius
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AfterAuthPanel.DataContext = Properties.Settings.Default;
            HelloBox.DataContext = Properties.Settings.Default;
            AllCaseButton.DataContext = Properties.Settings.Default;
            AddButton.DataContext = Properties.Settings.Default;
            QueryButton.DataContext = Properties.Settings.Default;
            Properties.Settings.Default.AllButtonColor = "#148ad9";
            Properties.Settings.Default.AddButtonColor = "#005691";
            Properties.Settings.Default.QueryButtonColor = "#005691";
            MainFrame.Navigate(new AuthPage());
        }

        private void AllCaseButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllCasePage());
            Properties.Settings.Default.AllButtonColor = "#148ad9";
            Properties.Settings.Default.AddButtonColor = "#005691";
            Properties.Settings.Default.QueryButtonColor = "#005691";
        }

        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AllQueryPage());
            Properties.Settings.Default.AllButtonColor = "#005691";
            Properties.Settings.Default.AddButtonColor = "#005691";
            Properties.Settings.Default.QueryButtonColor = "#148ad9";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AddCasePage());
            Properties.Settings.Default.AllButtonColor = "#005691";
            Properties.Settings.Default.AddButtonColor = "#148ad9";
            Properties.Settings.Default.QueryButtonColor = "#005691";
        }
    }
}
