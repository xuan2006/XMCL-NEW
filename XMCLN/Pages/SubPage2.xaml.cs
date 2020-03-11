using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Net;
using System.IO;

namespace XMCLN.Pages
{
    /// <summary>
    /// SubPage2.xaml 的交互逻辑
    /// </summary>
    public partial class SubPage2 : Page
    {
        static List<string> T = new List<string>();
        static int A;
        public SubPage2()
        {
            InitializeComponent();
        }
        public static void choose(string version,Frame frame)
        {
            Page page = new SubPage2();
            frame.Navigate(page);
            if (version == "原版")
                A = 0;
            else if (version == "forge")
                A = 1;
            else if (version == "optifine")
                A = 2;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (A==0)
            {
                Thread thread = new Thread(() =>
                {
                    string[] vs = XMCL.Core.Tools.GetVersionsListAll().ToArray();
                    for (int i = 0; i < vs.Count(); i++)
                    {
                        string[] a1 = vs[i].Split(',');
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            ListView1.Items.Add(new { T1 = a1[0], T2 = a1[1], T3 = a1[2], T4 = a1[3] });
                        }));
                        T.Add(a1[2]);
                    }
                });
                thread.Start();
            }
            if (A == 1)
            {

            }
            if (A == 2)
            {
                Thread thread = new Thread(() =>
                {
                    string[] vs = XMCL.Core.Tools.GetVersionsListAll_Optifine().ToArray();
                    for (int i = 0; i < vs.Count(); i++)
                    {
                        string[] a1 = vs[i].Split(',');
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            ListView1.Items.Add(new { T1 = a1[0], T2 = a1[1], T3 = a1[2], T4 = a1[3] });
                        }));
                        T.Add(a1[2]);
                    }
                });
                thread.Start();
            }
        }

        private void DownloadVersion_Click(object sender, RoutedEventArgs e)
        {
            if (A==0)
            {
                int a = ListView1.SelectedIndex;
                string c = System.IO.Path.GetFileName(T[a]);
                string b;
                if (Convert.ToBoolean(Json.Read("Files", "UseDefaultDirectory")))
                    b = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\versions\\" + c.Substring(0, c.Length - 5) + "\\";
                else b = Json.Read("Files", "GamePath") + "\\versions\\" + c.Substring(0, c.Length - 5) + "\\";
                WebClient client = new WebClient();
                if (Directory.Exists(b))
                { }
                else { Directory.CreateDirectory(b); }
                client.DownloadFile(T[a], b + System.IO.Path.GetFileName(T[a]));
                MessageBox.Show("下载完成");
            }
            else
            {
                int a = ListView1.SelectedIndex;
                string name = Tools.GetVersionsListAll_Optifine().ToArray()[a].Split(',')[0];
                string URL = T[a];

                Thread thread = new Thread(() =>
                {
                    HttpWebRequest httpWebRequest = WebRequest.Create(URL) as HttpWebRequest;
                    HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;

                    Stream stream = httpWebResponse.GetResponseStream();

                    byte[] BArr = new byte[1024];
                    int size = stream.Read(BArr, 0, BArr.Length);
                    if (Directory.Exists(Directory.GetCurrentDirectory() + "\\Dwonload\\"))
                    { }
                    else Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\Dwonload\\");
                    FileStream file = File.OpenWrite(Directory.GetCurrentDirectory() + "\\Dwonload\\" + name + ".jar");
                    while (size > 0)
                    {
                        file.Write(BArr, 0, size);
                        size = stream.Read(BArr, 0, BArr.Length);
                    }
                    file.Close();
                    stream.Close();
                    httpWebResponse.Close();

                    System.GC.Collect();
                    MessageBox.Show("下载完成");
                    System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "\\Dwonload\\" + name + ".jar");
                });
                thread.Start();
            }
        }
    }
}
