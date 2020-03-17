using System;
using System.Windows;
using System.Windows.Controls;
using WinForm = System.Windows.Forms;
using XMCL.Core;

namespace XMCLN
{
    /// <summary>
    /// Setting1.xaml 的交互逻辑
    /// </summary>
    public partial class Setting1 : Page
    {
        public Setting1()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(Json.Read("Video", "IsFullScreen")))
                ToggleButton.IsChecked = true;
            if (Convert.ToBoolean(Json.Read("Game", "Demo")))
                ToggleButton1.IsChecked = true;
            if (Convert.ToBoolean(Json.Read("Files", "UseDefaultDirectory")))
                R1.IsChecked = true;
            else R2.IsChecked = true;
            TextBox_GamePath.Text = Json.Read("Files", "GamePath");
            TextBox_JavaPath.Text = Json.Read("Files", "JavaPath");
            TextBox_Memory.Text = Json.Read("JVM", "Memory");
            TextBox_Width.Text = Json.Read("Video", "Width");
            TextBox_Height.Text = Json.Read("Video", "Height");
            TextBox_ServerIP.Text = Json.Read("Game", "ServerIP");
        }

        private void R1_Checked(object sender, RoutedEventArgs e)
        {
            TextBox_GamePath.IsEnabled = Button_OpenGame.IsEnabled = false;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (ToggleButton.IsChecked == true)
                Json.Write("Video", "IsFullScreen", "true");
            else Json.Write("Video", "IsFullScreen", "false");
            if (ToggleButton1.IsChecked == true)
                Json.Write("Game", "Demo", "true");
            else Json.Write("Game", "Demo", "false");
            if (R1.IsChecked == true)
                Json.Write("Files", "UseDefaultDirectory", "true");
            if (R2.IsChecked == true)
                Json.Write("Files", "UseDefaultDirectory", "false");
            Json.Write("Files", "GamePath", TextBox_GamePath.Text);
            Json.Write("Files", "JavaPath", TextBox_JavaPath.Text);
            Json.Write("JVM", "Memory", TextBox_Memory.Text);
            Json.Write("Video", "Width", TextBox_Width.Text);
            Json.Write("Video", "Height", TextBox_Height.Text);
            Json.Write("Game", "ServerIP", TextBox_ServerIP.Text);
            
        }

        private void R2_Checked(object sender, RoutedEventArgs e)
        {
            TextBox_GamePath.IsEnabled = Button_OpenGame.IsEnabled = true;
        }

        private void Button_OpenGame_Click(object sender, RoutedEventArgs e)
        {
            WinForm.FolderBrowserDialog dialog = new WinForm.FolderBrowserDialog();
            dialog.ShowDialog();
            TextBox_GamePath.Text = dialog.SelectedPath;
            dialog.Dispose();
        }

        private void Button_OpenJava_Click(object sender, RoutedEventArgs e)
        {
            WinForm.OpenFileDialog dialog = new WinForm.OpenFileDialog();
            dialog.Filter = "javaw.exe|javaw.exe";
            dialog.Title = "选择Java";
            dialog.ShowDialog();
            TextBox_JavaPath.Text = dialog.FileName;
            dialog.Dispose();
        }

    }
}
