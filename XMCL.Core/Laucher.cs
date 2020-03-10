﻿using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows;
using System;
namespace XMCL.Core
{
    public class Check
    {
        public static bool CanLauch = true;
        public static bool check()
        {
            bool a;
            a = Directory.Exists(Value.GamePath);
            if (a)
                a = File.Exists(Value.JavaPath);
            if (a)
                if (Value.Selected_Version.Length == 0)
                    a = false;
            return a;
        }
    }
    public class Game
    {
        public static System.Collections.Generic.List<string> ZipList = new System.Collections.Generic.List<string>();
        public static DownLoadHelper downLoadHelper = new DownLoadHelper();
        static Process process = new Process();
        public static void Run()
        {
            if (Check.check())
            {
                downLoadHelper.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                Value.Resource();
                string A = Value.Arguments();
                downLoadHelper.start();
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\start.log", "java " + A);
                if (Directory.Exists(Value.GamePath + "\\versions\\" + Value.Selected_Version + "\\" + Value.Selected_Version + "-natives"))
                    DelectDir(Value.GamePath + "\\versions\\" + Value.Selected_Version + "\\" + Value.Selected_Version + "-natives");
                else Directory.CreateDirectory(Value.GamePath + "\\versions\\" + Value.Selected_Version + "\\" + Value.Selected_Version + "-natives");
                for (int i = 0; i < ZipList.Count; i++)
                {
                    try { ZipFile.ExtractToDirectory(ZipList[i], Value.GamePath + "\\versions\\" + Value.Selected_Version + "\\" + Value.Selected_Version + "-natives"); } catch { }
                    try { DelectDir(Value.GamePath + "\\versions\\" + Value.Selected_Version + "\\" + Value.Selected_Version + "-natives\\META-INF"); }
                    catch { }

                }
                if (Check.CanLauch)
                {
                    if(File.Exists(Value.GamePath+ "\\launcher_profiles.json"))
                    { }else {
                        FileStream fs1 = new FileStream(Value.GamePath + "\\launcher_profiles.json", FileMode.Create, FileAccess.ReadWrite);
                        try
                        {
                            fs1.Write(Resource1.launcher_profiles, 0, Resource1.launcher_profiles.Length);
                            fs1.Flush();
                            fs1.Close();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    process.StartInfo.FileName = Value.JavaPath;
                    process.StartInfo.Arguments = A;
                    process.Start();
                }
                else
                {
                    downLoadHelper.Owner.Activate();
                    System.Windows.MessageBox.Show(Error.ToString());
                    Error = new StringBuilder();
                    Check.CanLauch = true;
                }
                Window window = downLoadHelper.Owner;
                downLoadHelper = new DownLoadHelper();
                downLoadHelper.Owner = window;
            }
            else
            {
                MessageBox.Show("无法启动，请检查\r\n1.游戏目录是否正确\r\n2.java目录是否正确\r\n3.是否选择启动的版本");
            }
        }
        public static void Stop()
        {
            try
            {
                if (process.HasExited)
                { }
                else { process.Kill(); }
            }
            catch { }
        }
        public static StringBuilder Error = new StringBuilder();
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        //如果 使用了 streamreader 在删除前 必须先关闭流 ，否则无法删除 sr.close();
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch
            {

            }
        }
    }
}
