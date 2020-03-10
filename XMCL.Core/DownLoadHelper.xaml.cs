using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
namespace XMCL.Core
{
    /// <summary>
    /// DownLoadHelper.xaml 的交互逻辑
    /// </summary>
    public partial class DownLoadHelper : Window
    {
        int DownloadedCount = 0;

        public List<string> DownloadFileList = new List<string>();
        public List<string> DownloadURLList = new List<string>();
        Thread Task;
        Thread Task1;
        Thread Task2;
        Thread Task3;
        Thread Task4;
        Thread Task5;
        public DownLoadHelper()
        {
            InitializeComponent();
        }
        public void DownloadFile(string URL, string filename, ProgressBar prog, Label label)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (prog != null)
                    {
                        prog.Maximum = (int)totalBytes;
                    }
                }));

                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (prog != null)
                        {
                            prog.Value = (int)totalDownloadedByte;
                        }
                    }));
                    osize = st.Read(by, 0, (int)by.Length);
                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        label.Content = "正在下载..." + percent.ToString() + "%    " + System.IO.Path.GetFileName(URL);
                    }));
                }
                myrp.Dispose();
                so.Close();
                st.Close();
                DownloadedCount += 1;
            }
            catch (System.Exception)
            {
                DownloadedCount += 1;
            }
        }
        public void start()
        {
            ThreadPool.SetMaxThreads(6, 6);
            int StartDownload = 0;
            Task = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB1, Label1);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task1 = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB2, Label2);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task2 = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB3, Label3);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task3 = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB4, Label4);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task4 = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB5, Label5);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task5 = new Thread(() =>
            {
                while (StartDownload < DownloadFileList.Count)
                {
                    StartDownload += 1;
                    DownloadFile(DownloadURLList[StartDownload-1], DownloadFileList[StartDownload-1], PB6, Label6);
                }
                if (DownloadFileList.Count == DownloadedCount)
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.Close();
                    }));
            });
            Task.Start();Task1.Start();Task2.Start();Task3.Start();Task4.Start();Task5.Start();
            this.ShowDialog();
        }
    }
}
