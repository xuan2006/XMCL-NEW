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
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void SubPage1(object sender, MouseButtonEventArgs e)
        {
            Frame.Navigate(new SubPage1());
        }

        private void TreeViewItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            SubPage2.choose("forge", Frame);
        }

        private void TreeViewItem_PreviewMouseUp_1(object sender, MouseButtonEventArgs e)
        {
            SubPage2.choose("optifine", Frame);
        }

        private void TreeViewItem_PreviewMouseUp_2(object sender, MouseButtonEventArgs e)
        {
            SubPage2.choose("原版", Frame);
        }
    }
}
