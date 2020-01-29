using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SA2SaveUtility
{
    public class Updater
    {
        public static List<Release> releases;
        public static List<Release> releasesBehind;
        public static bool isLatest = true;
        public static bool checkForUpdates;
        public static bool autoUpdate;

        public static void UpdateApplication()
        {
            Release latest = releasesBehind.OrderByDescending(x => Version.Parse(x.tag_name)).First();
            using (var client = new WebClient())
            {
                client.DownloadFile(latest.assets[0].browser_download_url, "temp.exe");
                if (File.Exists("temp.exe"))
                {
                    Assembly currentAssembly = Assembly.GetEntryAssembly();
                    if (currentAssembly != null)
                    {
                        string currentFolder = Path.GetDirectoryName(currentAssembly.Location);
                        string currentName = Path.GetFileNameWithoutExtension(currentAssembly.Location);
                        string currentExtension = Path.GetExtension(currentAssembly.Location);
                        string tempFile = Path.Combine(currentFolder, "temp.exe");
                        string newFile = Path.Combine(currentFolder, latest.assets[0].name);
                        string currentFile = Path.Combine(currentFolder, currentName + currentExtension);
                        if (!Directory.Exists(Main.oldDir)) { Directory.CreateDirectory(Main.oldDir); }
                        string backupPath = Path.Combine(Main.oldDir, currentName + ".old");
                        File.Move(currentFile, backupPath);
                        File.Move(tempFile, newFile);
                        Application.Restart();
                    }
                }
            }
        }

        public static void UpdateCheck()
        {
            try
            {
                string projectJSON = "";

                using (WebClient client = new WebClient())
                {
                    client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";

                    projectJSON = client.DownloadString("https://api.github.com/repos/dfrood/SA2SaveUtility" + "/releases");
                }

                JavaScriptSerializer js = new JavaScriptSerializer();

                releases = js.Deserialize<List<Release>>(projectJSON);

                Version latestVersion = Main.currentVersion;

                releasesBehind = new List<Release>();

                foreach (Release release in releases)
                {
                    Version releaseBeingChecked = Version.Parse(release.tag_name);

                    if (Main.currentVersion.CompareTo(releaseBeingChecked) < 0)
                    {
                        latestVersion = releaseBeingChecked;
                        releasesBehind.Add(release);
                    }
                }

                releasesBehind.Reverse();

                if (Main.currentVersion.CompareTo(latestVersion) < 0)
                {
                    isLatest = false;
                    Main.btn_AutoUpdate.BeginInvoke(new MethodInvoker(() =>
                    {
                        Main.btn_AutoUpdate.Visible = true;
                    }));
                    if (!isLatest && autoUpdate) { UpdateApplication(); }
                }
                else
                {
                    isLatest = true;
                    Main.btn_AutoUpdate.BeginInvoke(new MethodInvoker(() =>
                    {
                        Main.btn_AutoUpdate.Visible = false;
                    }));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
