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
using System.IO;
using XMCL.Core;

namespace XMCLN
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Page1());
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Page1());
            GC.Collect();
            Game.downLoadHelper.Owner = this;
            Game.downLoadHelper.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Java.OwnerWindows = this;
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\XMCL.json"))
            { }
            else
            {
                FileStream fs1 = new FileStream(System.Environment.CurrentDirectory + "\\XMCL.json", FileMode.Create, FileAccess.ReadWrite);
                try
                {
                    fs1.Write(Resource.XMCL, 0, Resource.XMCL.Length);
                    fs1.Flush();
                    fs1.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            System.GC.Collect();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Page2());
            GC.Collect();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new Page3());
            GC.Collect();
        }

        private void Button_Mini(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            GC.Collect();
        }
    }
}
