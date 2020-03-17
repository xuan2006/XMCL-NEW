using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace XMCL.Core
{
    public class Json
    {
        static string a = System.IO.Directory.GetCurrentDirectory() + "\\XMCL.json";
        public static string Read(string Section, string Name)
        {
            if (System.IO.File.Exists(a))
            {
                string b = System.IO.File.ReadAllText(a);
                try
                {
                    return JObject.Parse(b)[Section][Name].ToString();
                }
                catch { return null; }
            }
            else
            {
                return null;
            }
        }
        public static void Write(string Section, string Name, string Text)
        {
            if (System.IO.File.Exists(a))
            {
                string b = System.IO.File.ReadAllText(a);
                try
                {
                    JObject jObject = JObject.Parse(b);
                    jObject[Section][Name] = Text;
                    string convertString = Convert.ToString(jObject);
                    System.IO.File.WriteAllText(a, convertString);
                }
                catch { }
            }
            else
            {
                System.Windows.MessageBox.Show("");
            }
        }

    }
    public class Value
    {
        public static void Set(string name, string memory, string gamepath, string javapath, string version, string morevalue, string uuid, string accesstoken, bool fullscreen, bool complementaryResources)
        {
            UserName = name; Memory = memory; GamePath = gamepath; JavaPath = javapath; Selected_Version = version; MoreValue = morevalue; UUID = uuid; AccessToken = accesstoken; IsFullScreen = fullscreen; ComplementaryResources = complementaryResources;
        }
        public static string UserName { get; set; }
        public static string Memory { set; get; }
        public static string GamePath { set; get; }
        public static string JavaPath { set; get; }
        public static string Selected_Version { set; get; }
        public static string MoreValue { get; set; }
        public static string UUID { get; set; }
        public static string AccessToken { get; set; }
        public static bool IsFullScreen { get; set; }
        public static bool ComplementaryResources { get; set; }
        public static bool IsDemo { get; set; }
        public static string ServerIP { get; set; }
        public static string Arguments()
        {
            StringBuilder Main = new StringBuilder();
            Main.Append(" -Xmx" + Memory + "M");
            Main.Append(MoreValue);
            Main.Append(" -Djava.library.path=" + GamePath + "\\versions\\" + Selected_Version + "\\" + Selected_Version + "-natives");
            Main.Append(" -Dminecraft.launcher.brand=XMCL.Core  -Dminecraft.launcher.version=2.3");
            Main.Append(" -Dminecraft.client.jar=" + GamePath + "\\versions\\" + Selected_Version + "\\" + Selected_Version + ".jar");

            string MainJson = File.ReadAllText(GamePath + "\\versions\\" + Selected_Version + "\\" + Selected_Version + ".json");
            JObject jObject = JObject.Parse(MainJson);
            StringBuilder CP = new StringBuilder(" -cp ");
            bool IsVanilla = true;
            string CPINFO;

            if (MainJson.Contains("inheritsFrom"))
                IsVanilla = false;
            if (IsVanilla == false)
            {
                CPINFO = GamePath + "\\versions\\" + jObject["inheritsFrom"].ToString() + "\\" + jObject["inheritsFrom"].ToString() + ".json";
            }
            else
            {
                CPINFO = GamePath + "\\versions\\" + Selected_Version + "\\" + Selected_Version + ".json";
            }

            string VersionJson = File.ReadAllText(CPINFO);
            JObject jObject1 = JObject.Parse(VersionJson);
            JArray jArray = JArray.Parse(jObject1["libraries"].ToString());
            int ID;
            try
            {
                 ID = Convert.ToInt32(jObject1["id"].ToString().Split('.')[1]);
            }
            catch
            {
                ID = Convert.ToInt32(jObject1["assets"].ToString().Split('.')[1]);
            }
            string url1 = null;

            if (File.Exists(CPINFO.Replace("json", "jar")))
            {
                if (new FileInfo(CPINFO.Replace("json", "jar")).Length == Convert.ToInt32(jObject1["downloads"]["client"]["size"].ToString()))
                { }
                else url1 = jObject1["downloads"]["client"]["url"].ToString();
            }
            else url1 = jObject1["downloads"]["client"]["url"].ToString();
            if (url1 == null)
            { }
            else
            {
                if (DownloadSource == "BMCLAPI")
                    url1 = url1.Replace("https://launcher.mojang.com/", BMCLAPI_URL);
                Game.downLoadHelper.DownloadFileList.Add(CPINFO.Replace("json", "jar")); Game.downLoadHelper.DownloadURLList.Add(url1); 
            }
            if (Directory.Exists(CPINFO.Substring(0, CPINFO.Length - CPINFO.Replace("\\", "!").Split('!')[CPINFO.Replace("\\", "!").Split('!').Length-1].Length)))
            { } else Directory.CreateDirectory(CPINFO.Substring(0, CPINFO.Length - CPINFO.Replace("\\", "!").Split('!')[CPINFO.Replace("\\", "!").Split('!').Length-1].Length));
            for (int i =0; i<jArray.Count;i++)
            {
                JObject jObject2 = JObject.Parse(jArray[i].ToString());
                string[] name = jObject2["name"].ToString().Split(':');
                if (jObject2["name"].ToString().Contains("3.2.1"))
                    continue;
                if (IsVanilla == false)
                    if (name[1] + "-" + name[2] + ".jar" == "guava-15.0.jar")
                        continue;
                string path = GamePath + "\\libraries\\" + name[0].Replace(".", "\\") + "\\" + name[1] + "\\" + name[2] + "\\" + name[1] + "-" + name[2] + ".jar";
                if (Directory.Exists(GamePath + "\\libraries\\" + name[0].Replace(".", "\\") + "\\" + name[1] + "\\" + name[2] + "\\"))
                { }
                else Directory.CreateDirectory(GamePath + "\\libraries\\" + name[0].Replace(".", "\\") + "\\" + name[1] + "\\" + name[2] + "\\");
                if (jArray[i].ToString().Contains("natives-windows"))
                {
                    if (jObject2["natives"]["windows"].ToString() == "natives-windows-${arch}")
                        path = path.Replace(".jar", "-natives-windows-64.jar");
                    else path = path.Replace(".jar", "-natives-windows.jar");
                    Game.ZipList.Add(path);
                    string url = null;
                    try
                    {
                        if (File.Exists(path))
                        {
                            if (jObject2["natives"]["windows"].ToString() == "natives-windows-${arch}")
                            {
                                if (new FileInfo(path).Length == Convert.ToInt32(jObject2["downloads"]["classifiers"]["natives-windows-64"]["size"].ToString()))
                                { }
                                else url = jObject2["downloads"]["classifiers"]["natives-windows-64"]["url"].ToString();
                            }
                            else
                            {
                                if (new FileInfo(path).Length == Convert.ToInt32(jObject2["downloads"]["classifiers"]["natives-windows"]["size"].ToString()))
                                { }
                                else url = jObject2["downloads"]["classifiers"]["natives-windows"]["url"].ToString();
                            }
                        }
                        else
                        {
                            if (jObject2["natives"]["windows"].ToString() == "natives-windows-${arch}")
                                url = jObject2["downloads"]["classifiers"]["natives-windows-64"]["url"].ToString();
                            else url = jObject2["downloads"]["classifiers"]["natives-windows"]["url"].ToString();
                        }
                    } catch { url = null; }
                    if (url == null)
                    { }
                    else
                    {
                        if (DownloadSource=="BMCLAPI")
                            url.Replace("https://libraries.minecraft.net/", BMCLAPI_URL + "maven");
                        Game.downLoadHelper.DownloadFileList.Add(path);
                        Game.downLoadHelper.DownloadURLList.Add(url);
                    }
                }
                else
                {
                    CP.Append(path + ";");
                    string url = null;
                    if (File.Exists(path))
                        if (new FileInfo(path).Length == Convert.ToInt32(jObject2["downloads"]["artifact"]["size"].ToString()))
                        { }
                        else url = jObject2["downloads"]["artifact"]["url"].ToString();
                    else url = jObject2["downloads"]["artifact"]["url"].ToString();
                    if (url == null)
                    { }
                    else
                    {
                        if (DownloadSource == "BMCLAPI")
                            url.Replace("https://libraries.minecraft.net/", BMCLAPI_URL + "maven");
                        Game.downLoadHelper.DownloadFileList.Add(path);
                        Game.downLoadHelper.DownloadURLList.Add(url);
                    }
                }
            }
            if (IsVanilla == false)
            {
                JArray jArray1 = JArray.Parse(jObject["libraries"].ToString());
                for (int i = 0; i < jArray1.Count; i++)
                {
                    JObject jObject2 = JObject.Parse(jArray1[i].ToString());
                    string[] name = jObject2["name"].ToString().Split(':');
                    string path = GamePath + "\\libraries\\" + name[0].Replace(".", "\\") + "\\" + name[1] + "\\" + name[2] + "\\" + name[1] + "-" + name[2] + ".jar";
                    CP.Append(path + ";");
                }
            }
            if (MainJson.ToLower().Contains("optifine"))
                CP.Append(GamePath + "\\versions\\" + Selected_Version + "\\" + Selected_Version + ".jar ");
            else CP.Append(GamePath + "\\versions\\" + jObject1["id"] + "\\" + jObject1["id"] + ".jar ");
            Main.Append(CP.ToString());
            Main.Append(jObject["mainClass"].ToString());
            if (ID >=13)
            {
                StringBuilder minecraftArguments = new StringBuilder();
                minecraftArguments.Append("--username ${auth_player_name} --version ${version_name} --gameDir ${game_directory} --assetsDir ${assets_root} --assetIndex ${assets_index_name} --uuid ${auth_uuid} --accessToken ${auth_access_token} --userType ${user_type} --versionType ${version_type} ");
                if (IsVanilla == false)
                {
                    JArray jArray2 = JArray.Parse(jObject["arguments"]["game"].ToString());
                    for (int i = 0; i < jArray2.Count; i++)
                    {
                        minecraftArguments.Append(" " + jArray2[i].ToString());
                    }
                }
                string assets_index_name;
                if (IsVanilla == true)
                    assets_index_name = jObject["assets"].ToString();
                else assets_index_name = jObject1["assets"].ToString();
                string Finally = minecraftArguments.ToString().Replace("${auth_player_name}", UserName)
                    .Replace("${version_name}", Selected_Version).Replace("${game_directory}", GamePath).Replace("${assets_root}", GamePath + "\\assets")
                    .Replace("${assets_index_name}", assets_index_name).Replace("${auth_uuid}", UUID).Replace("${auth_access_token}", AccessToken)
                    .Replace("${user_type}", "Mojang").Replace("${version_type}", "XMCL.Core");
                Main.Append(" " + Finally);
            }
            else
            {
                string assets_index_name;
                if (IsVanilla == true)
                    assets_index_name = jObject["assets"].ToString();
                else assets_index_name = jObject1["assets"].ToString();
                string minecraftArguments = jObject["minecraftArguments"].ToString().Replace("${auth_player_name}", UserName)
                    .Replace("${version_name}", Selected_Version).Replace("${game_directory}", GamePath).Replace("${assets_root}", GamePath + "\\assets")
                    .Replace("${assets_index_name}", assets_index_name).Replace("${auth_uuid}", UUID).Replace("${auth_access_token}", AccessToken)
                    .Replace("${user_type}", "Mojang").Replace("${version_type}", "XMCL.Core").Replace("${user_properties}","{}");
                Main.Append(" "+minecraftArguments);
            }
            if (ServerIP == null)
            { }
            else
            {
                if(ServerIP.Length==0)
                {
                    
                }
                else
                {
                    if (ServerIP.Contains(";"))
                    {
                        string[] a = ServerIP.Split(';');
                        Main.Append(" --server " + a[0]);
                        Main.Append(" --port " + a[1]);
                    }
                    else
                    {
                        Main.Append(" --server " + ServerIP);
                        Main.Append(" --port " + "25565");
                    }
                }
            }
            if (IsDemo == true)
                Main.Append(" --demo");
            return Main.ToString();
        }
        public static void Resource()
        {
            try
            {
                string a = GamePath;
                JObject jObject = JObject.Parse(File.ReadAllText(a + "\\versions\\" + Selected_Version + "\\" + Selected_Version + ".json"));
                if (ComplementaryResources)
                {
                    JObject jObject1;
                    if (jObject["id"].ToString().ToLower().Contains("forge"))
                    {
                        string z = jObject["inheritsFrom"].ToString();
                        jObject = JObject.Parse(File.ReadAllText(a + "\\versions\\" + z + "\\" + z + ".json"));
                        jObject1 = JObject.Parse(jObject["assetIndex"].ToString());
                    }
                    else
                    {
                        jObject1 = JObject.Parse(jObject["assetIndex"].ToString());
                    }
                    if (Directory.Exists(a + "\\assets\\indexes"))
                    { }
                    else Directory.CreateDirectory(a + "\\assets\\indexes");
                    if (File.Exists(a + "\\assets\\indexes\\" + jObject1["id"].ToString() + ".json"))
                    { }
                    else
                    {
                        WebClient client = new WebClient();
                        client.DownloadFile(jObject1["url"].ToString(), a + "\\assets\\indexes\\" + jObject1["id"].ToString() + ".json");
                    }
                    string b = File.ReadAllText(a + "\\assets\\indexes\\" + jObject1["id"].ToString() + ".json");
                    JObject json = JObject.Parse(b);
                    JObject jObject2 = JObject.Parse(json["objects"].ToString());
                    string[] vs = jObject2.ToString().Replace("\r\n", "").Replace(" ", "").Replace("},", "$").Split('$');
                    for (int i = 0; i < vs.Length; i++)
                    {
                        string a1 = vs[i] + "}";
                        string a2 = "{" + a1.Replace(":{", "$").Split('$')[1];
                        JObject jo = JObject.Parse(a2.Replace("}", "") + "}");
                        string c = jo["hash"].ToString().Substring(0, 2);
                        string d = "http://resources.download.minecraft.net/" + c + "/" + jo["hash"];
                        if (DownloadSource == "BMCLAPI")
                            d.Replace("http://resources.download.minecraft.net/", BMCLAPI_URL + "assets");
                        if (Directory.Exists(a + "\\assets\\objects\\" + c))
                        { }
                        else { Directory.CreateDirectory(a + "\\assets\\objects\\" + c); }
                        string e = a + "\\assets\\objects\\" + c + "\\" + jo["hash"];
                        if (File.Exists(e))
                        {
                            if (new FileInfo(e).Length == Convert.ToInt32(jo["size"].ToString()))
                            { }
                            else { Game.downLoadHelper.DownloadFileList.Add(e); Game.downLoadHelper.DownloadURLList.Add(d); }
                        }
                        else
                        {
                            Game.downLoadHelper.DownloadFileList.Add(e); Game.downLoadHelper.DownloadURLList.Add(d);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Game.Error.Append("无法补全资源文件" + ex.Message);
            }
        }
        public static string DownloadSource = "Mojang";
        static string BMCLAPI_URL = "https://bmclapi2.bangbang93.com/";
    }
}
