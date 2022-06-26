﻿using System;
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

namespace Hedaozi.DataCollector.WPF.Pages
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        public Home() => InitializeComponent();

        private void GoToPage(object sender, RoutedEventArgs e) => ((MainWindow)Window.GetWindow(this)).Frame.Source = new Uri(((Button)sender).Tag.ToString(), UriKind.Relative);
    }
}
