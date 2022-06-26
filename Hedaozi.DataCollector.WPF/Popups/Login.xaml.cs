using Microsoft.Web.WebView2.Core;
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
using System.Windows.Shapes;

namespace Hedaozi.DataCollector.WPF.Popups
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private Dictionary<string, string> cookies = new Dictionary<string, string>();
        public string UserAgent { get; set; }
        public Dictionary<string, string> Cookies { get { return cookies; } }

        public Login(string url)
        {
            InitializeComponent();
            WebView.Source = new Uri(url);
        }

        private async void GetHeader(object sender, EventArgs e)
        {
            UserAgent = WebView.CoreWebView2.Settings.UserAgent;
            List<CoreWebView2Cookie> cookies = await WebView.CoreWebView2.CookieManager.GetCookiesAsync(null);
            foreach (CoreWebView2Cookie cookie in cookies)
            {
                Cookies.Add(cookie.Name, cookie.Value);
            }
        }
    }
}
