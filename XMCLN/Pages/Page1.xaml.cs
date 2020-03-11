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

        private void Login(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Label_Name.Content = Json.Read("Login", "userName");
            Thread thread = new Thread(() =>
            {
                if (App.Logined)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (App.IsOnline)
                        {
                            Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                            Label_Login.Content = "正版登录";
                        }
                        else Label_Login.Content = "离线登录";
                    }));
                }
                else
                {
                    if (XMCL.Core.Authenticate.Refresh(Json.Read("Login", "accessToken"), Json.Read("Login", "clientToken")))
                    {
                        App.Logined = true; App.IsOnline = true;
                        XMCL.Core.Tools.GetSkins(Json.Read("Login", "uuid"));
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Label_Login.Content = "正版登录";
                            Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                        }));
                    }
                    else
                    {
                        bool a = false;
                        if (Json.Read("Login", "uuid").Length > 0)
                            if (Json.Read("Login", "userName").Length > 0)
                                a = true;
                        if (a)
                        {
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                Label_Login.Content = "离线登录";
                            }));
                        }
                        else
                        {
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                this.NavigationService.Navigate(new Page4());
                            }));

                        }
                        App.Logined = true;
                        App.IsOnline = false;
                    }
                }
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Load.Visibility = Visibility.Collapsed;
                }));
            });
            thread.Start(); 
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
