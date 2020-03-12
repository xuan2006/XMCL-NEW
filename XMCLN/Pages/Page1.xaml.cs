using System.Threading;
using System.Windows;
using System.Windows.Controls;
using XMCL.Core;
using System.Windows.Media.Imaging;
using System;
using System.IO;
namespace XMCLN
{
    /// <summary>
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Json.Read("Files", "UseDefaultDirectory")))
                C1.ItemsSource = Tools.GetVersions(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft");
            else C1.ItemsSource = Tools.GetVersions(Json.Read("Files", "GamePath"));
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            string GamePath;
            if (Convert.ToBoolean(Json.Read("Files", "UseDefaultDirectory")))
                GamePath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft");
            else GamePath = Json.Read("Files", "GamePath");
            Value.Set(Json.Read("Login", "userName"),Json.Read("JVM", "Memory"),GamePath, Json.Read("Files", "JavaPath"),C1.Text,Json.Read("JVM", "Value"),Json.Read("Login","uuid"), Json.Read("Login", "accessToken"),Convert.ToBoolean(Json.Read("Video", "IsFullScreen")),Convert.ToBoolean(Json.Read("Files", "CompleteResource")));
            Value.DownloadSource = Json.Read("Files", "DownloadSource");
            Value.ServerIP = Json.Read("Game", "ServerIP");
            Value.IsDemo = Convert.ToBoolean(Json.Read("Game", "Demo"));
            Game.Run();
        }
    }
}
