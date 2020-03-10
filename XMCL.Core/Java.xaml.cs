using System.Windows;
namespace XMCL.Core
{
    /// <summary>
    /// Java.xaml 的交互逻辑
    /// </summary>
    public partial class Java : Window
    {
        public static Window OwnerWindows { get; set; }
        public static string a { get; set; }
        public Java()
        {
            InitializeComponent();
        }
        public static string ChooseJava()
        {
            Java java = new Java();
            try { java.Owner = OwnerWindows; } catch { }
            java.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            java.ShowDialog();
            return a;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = Tools.GetJavaList();
        }

        private void JavaOpen(object sender, RoutedEventArgs e)
        {
            try
            {
                a = ListBox1.SelectedItem.ToString();
            }
            catch { a = ""; }
            this.Close();
        }
    }
}
