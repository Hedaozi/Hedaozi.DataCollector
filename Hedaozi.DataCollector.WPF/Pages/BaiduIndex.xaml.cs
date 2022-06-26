using Hedaozi.DataCollector.WPF.ViewModels;
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
    /// BaiduIndex.xaml 的交互逻辑
    /// </summary>
    public partial class BaiduIndex : Page
    {
        BaiduIndexVM vm = new BaiduIndexVM();

        public BaiduIndex()
        {
            InitializeComponent();
            DataContext = vm;
            AreaTypeSelector.ItemsSource = BaiduIndexVM.AreaTypesEnum;
            BelongsSelector.ItemsSource = BaiduIndexVM.BelongsEnum;
        }
    }
}
