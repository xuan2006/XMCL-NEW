using System;
using System.Windows;
using System.Windows.Controls;
using XMCL.Core;

namespace XMCLN
{
    /// <summary>
    /// Page4.xaml 的交互逻辑
    /// </summary>
    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (C1.Text == "正版登录")
            {
                try
                {
                    if (Authenticate.Login(NameTextBox.Text, PasswordBox.Password))
                    {
                        this.NavigationService.Navigate(new Page1());
                        XMCL.Core.Tools.GetSkins(Json.Read("Login", "uuid"));
                    }
                    else
                    {
                        MessageBox.Show("登陆失败");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("登陆失败," + ex.Message);
                }
            }
            else
            {
                Authenticate.Offline(NameTextBox.Text);
                this.NavigationService.Navigate(new Page1());
            }
        }

        private void C1_DropDownClosed(object sender, EventArgs e)
        {
            if (C1.Text == "离线登录")
                PasswordBox.Visibility = Visibility.Hidden;
            else PasswordBox.Visibility = Visibility.Visible;
        }
    }
}
