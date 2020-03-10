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
            if (App.Logined)
            {
                Thread thread = new Thread(() =>
                {
                    if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"))
                    {
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                            Load.Visibility = Visibility.Collapsed;
                        }));
                    }
                    else
                    {
                        Tools.GetSkins(Json.Read("Login", "uuid"));
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                            Load.Visibility = Visibility.Collapsed;
                        }));
                    }
                });
                thread.Start();
                Label_Login.Content = "正版登录";
            }
            else
            {
                Thread thread1 = new Thread(() =>
                {
                    if (Authenticate.Refresh(Json.Read("Login", "accessToken"), Json.Read("Login", "clientToken")))
                    {
                        App.Logined = true;
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Label_Login.Content = "正版登录";
                        }));
                        if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"))
                        {
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                                Load.Visibility = Visibility.Collapsed;
                            }));
                        }
                        else
                        {
                            Tools.GetSkins(Json.Read("Login", "uuid"));
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                Image_Skin.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "\\user\\" + Json.Read("Login", "userName") + "\\head.png"));
                                Load.Visibility = Visibility.Collapsed;
                            }));
                        }
                    }
                    else App.Logined = false;
                });
                thread1.Start();
            }
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
            Value.Set(Json.Read("Login", "userName"),Json.Read("JVM", "Memory"),Json.Read("Files","GamePath"), Json.Read("Files", "JavaPath"),C1.Text,Json.Read("JVM", "Value"),Json.Read("Login","uuid"), Json.Read("Login", "accessToken"),Convert.ToBoolean(Json.Read("Video", "IsFullScreen")),Convert.ToBoolean(Json.Read("Files", "CompleteResource")));
            Game.Run();
        }
    }
}
