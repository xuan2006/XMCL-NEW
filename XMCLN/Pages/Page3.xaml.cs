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
using XMCLN.Pages;

namespace XMCLN
{
    /// <summary>
    /// Page3.xaml 的交互逻辑
    /// </summary>
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Set1(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(new Setting1());
        }
        private void Set2(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(new Setting2());
        }

    }
}
