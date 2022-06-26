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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace Hedaozi.DataCollector.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadWallpaper();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, StringBuilder lpvParam, uint init);

        private void MinimizeWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void MaximizeWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Maximized;

        private void NormalizeWindow(object sender, RoutedEventArgs e) => WindowState = WindowState.Normal;

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();

        private void DragWindow(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(TitleBarBlank);
            if (e.LeftButton == MouseButtonState.Pressed && 
                p.X < TitleBarBlank.ActualWidth &&
                p.Y < TitleBarBlank.ActualHeight)
            {
                DragMove();
            }

            i += 1;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;
            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                WindowState = WindowState == WindowState.Maximized ?
                    WindowState.Normal : WindowState.Maximized;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MaximizeButton.Visibility = Visibility.Hidden;
                NormalizeButton.Visibility = Visibility.Visible;
            }
            else
            {
                MaximizeButton.Visibility = Visibility.Visible;
                NormalizeButton.Visibility = Visibility.Hidden;
            }

            bool navigationCollapsed = ActualWidth < 800;
            NavigationPanel.Visibility = navigationCollapsed ? Visibility.Collapsed : Visibility.Visible;
            ShowNavigationButton.Visibility = navigationCollapsed ?
                Visibility.Visible : Visibility.Collapsed;
            ContentPanel.Width = navigationCollapsed ?
                ActualWidth : (ActualWidth > 1350 ? 1050 : ActualWidth - 300);
            ContentPanel.Margin = new Thickness(navigationCollapsed ? 0 : 300, 0, 0, 0);
            NavigationPanel.Background = navigationCollapsed ?
                new SolidColorBrush(Color.FromArgb(0xFF, 0xF3, 0xF3, 0xF3)) :
                new SolidColorBrush(Colors.Transparent);
            NavigationPanel.BorderThickness = navigationCollapsed ?
                new Thickness(0.5, 0, 0, 0.5) :
                new Thickness(0, 0, 0, 0);
        }
        
        private void LoadWallpaper()
        {
            const uint SPI_GETDESKWALLPAPER = 0x0073;
            StringBuilder wallpaperPath = new StringBuilder(200);

            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallpaperPath, 0) &&
                System.IO.File.Exists(wallpaperPath.ToString()))
            {
                Wallpaper.Source = new BitmapImage(new Uri(wallpaperPath.ToString()));
            }
            
        }

        private void Window_Deactivated(object sender, EventArgs e) => ColorMask.Visibility = Visibility.Visible;

        private void Window_Activated(object sender, EventArgs e) => ColorMask.Visibility = Visibility.Hidden;

        private void FrameGoBack(object sender, RoutedEventArgs e) => Frame.GoBack();

        private void ShowNavigation()
        {
            NavigationMask.Visibility = NavigationMask.Visibility == Visibility.Collapsed ?
                Visibility.Visible : Visibility.Collapsed;
            NavigationPanel.Visibility = NavigationPanel.Visibility == Visibility.Collapsed ?
                Visibility.Visible : Visibility.Collapsed;
        }
        private void ShowNavigation(object sender, RoutedEventArgs e) => ShowNavigation();

        private void NavigateTo(object sender, RoutedEventArgs e)
        {
            if (Frame != null && sender != null && ((RadioButton)sender).Tag != null)
            {
                Frame.Source = new Uri(string.Format("Pages/{0}.xaml", ((RadioButton)sender).Tag.ToString()), UriKind.Relative);
                if (ActualWidth < 800) ShowNavigation();
            }
        }
    }
}
