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
    /// Setting2.xaml 的交互逻辑
    /// </summary>
    public partial class Setting2 : Page
    {
        public Setting2()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Json.Read("Files", "DownloadSource")=="Mojang")
            {
                C1.SelectedIndex = 0;
            }
            else if (Json.Read("Files", "DownloadSource") == "BMCLAPI")
            {
                C1.SelectedIndex = 1;
            }
            else
            {
                C1.SelectedIndex = 0;
            }
            if (Convert.ToBoolean(Json.Read("Files", "CompleteResource")))
                ToggleButton.IsChecked = true;
            else ToggleButton.IsChecked = false;

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Json.Write("Files", "DownloadSource", C1.Text);
            if (ToggleButton.IsChecked == true)
                Json.Write("Files", "CompleteResource", "true");
            else Json.Write("Files", "CompleteResource", "false");
        }
    }
}
