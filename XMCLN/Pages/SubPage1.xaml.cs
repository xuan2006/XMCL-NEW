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
using XMCL.Core;

namespace XMCLN.Pages
{
    /// <summary>
    /// SubPage1.xaml 的交互逻辑
    /// </summary>
    public partial class SubPage1 : Page
    {
        public SubPage1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(Json.Read("Files", "UseDefaultDirectory")))
                List1.ItemsSource = Tools.GetVersions(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft");
            else List1.ItemsSource = Tools.GetVersions(Json.Read("Files", "GamePath"));
        }
    }
}
