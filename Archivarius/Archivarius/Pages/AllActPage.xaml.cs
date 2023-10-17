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
    /// Логика взаимодействия для AllActPage.xaml
    /// </summary>
    public partial class AllActPage : Page
    {
        public AllActPage(Worker worker)
        {
            InitializeComponent();
            Properties.Settings.Default.FullName = "Здравствуйте, " + worker.Name + " " + 
                (worker.Patronimyc ?? "") + "!";
        }
    }
}
