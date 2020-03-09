using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using XMCL.Core;

namespace XMCL
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }
        public MainWindow()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
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
            WindowLogin.WindowLoginOwner = this;
            Java.OwnerWindows = this;
            if (System.IO.File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\XMCL.json"))
            { }
            else
            {
                FileStream fs1 = new FileStream(System.Environment.CurrentDirectory + "\\XMCL.json", FileMode.Create, FileAccess.ReadWrite);
                try
                {
                    fs1.Write(Properties.Resources.XMCL, 0, Properties.Resources.XMCL.Length);
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
