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

namespace Hedaozi.DataCollector.WPF.Pages
{
    /// <summary>
    /// WeiboSearch.xaml 的交互逻辑
    /// </summary>
    public partial class WeiboSearch : Page
    {
        public WeiboSearch()
        {
            InitializeComponent();
        }

        private void LoginWeibo(object sender, RoutedEventArgs e)
        {
            Popups.Login wbLogin = new Popups.Login("https://weibo.com/login.php");
            wbLogin.Show();
        }
    }
}
