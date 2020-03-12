using System;
using System.Windows;
using System.Windows.Controls;
using XMCL.Core;
using System.Threading;


namespace XMCLN
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        public static void login()
        {
            Window1 window1 = new Window1();
            window1.Owner = Window;
            window1.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window1.ShowDialog();
        }
        public static Window Window { get; set; }
        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
                PasswordBox.Visibility = Visibility.Visible;
            else PasswordBox.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
            {
                try
                {
                    Authenticate.Login(NameTextBox.Text, PasswordBox.Password);
                    this.Close();
                } catch { }
            }
            else 
            {
                Authenticate.Offline(NameTextBox.Text);
                this.Close();
            }
        }
    }
}
