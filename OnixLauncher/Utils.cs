using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace OnixLauncher
{
    public static class Utils
    {
        public static string OnixPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        @"\Onix Launcher";

        public static string RPCServerPath = 
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
             + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\RoamingState\OnixClient\Launcher\server.txt";

        public static string DLLPath = OnixPath + @"\OnixClient.dll";

        private static OpenFileDialog _fileDialog;
        private static bool _init;
        public static string SelectedPath = "no file";
        public static MessageForm MessageF = new MessageForm("you shouldn't see this", "how are you reading this");
        public static SettingsForm SettingsF = new SettingsForm();
        public static Settings CurrentSettings = Settings.Load();
        public static bool IsOnline;

        // cache stuff
        public static string CachedVersion = "", CachedArchitecture = "";
        public static BackgroundWorker PreloadWorker;
        public static bool Loaded;

        public static void CheckOnline()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://github.com/");
            request.Timeout = 10000;
            request.Method = "HEAD";
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    IsOnline = response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (WebException)
            {
                IsOnline = false;
            }

            if (!IsOnline)
            {
                if (File.Exists(DLLPath))
                {
                    ShowMessage("Offline Mode",
                        "We couldn't contact GitHub servers, so launching will inject the DLL you had from last launch.");
                }
                else
                {
                    ShowMessage("Network Error", 
                        "We couldn't reach GitHub servers, and you don't have the DLL downloaded. Try launching later.");
                    Thread t = new Thread(() =>
                    {
                        while (MessageF.Visible)
                        {
                            Thread.Sleep(5);
                        }
                        MainForm.Instance.Close();
                    });
                    t.Start();
                }
            }
        }

        public static void StartPreload()
        {
            PreloadWorker = new BackgroundWorker();
            PreloadWorker.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs e)
            {
                GetVersion();
                GetArchitecture();

                if (IsOnline)
                {
                    var client = new WebClient();
                    Launcher.VersionList = client.DownloadString(
                        "https://raw.githubusercontent.com/bernarddesfosse/onixclientautoupdate/main/LatestSupportedVersion");
                }
            });
            PreloadWorker.RunWorkerAsync();
            PreloadWorker.RunWorkerCompleted += (s, v) =>
            {
                Loaded = true;
                Log.Write("Preload complete");

                // wtf
                Log.Write("Version list: " + Launcher.VersionList);
            };
        }

        public static void ShowMessage(string title, string subtitle)
        {
            Log.Write("Showing a message box: " + title);
            MessageF.SetTitleAndSubtitle(title, subtitle);
            MessageF.Owner = MainForm.Instance;
            MessageF.Show();
        }

        public static void ShowSettings()
        {
            SettingsF.Owner = MainForm.Instance;
            SettingsF.Show();
        }

        public static void UpdateSettings()
        {
            Settings.Save(CurrentSettings); // bro
            CurrentSettings = Settings.Load();

            MainForm.Instance.UpdateGradientSettings();
            SettingsF.InsiderToggle.Checked = CurrentSettings.InsiderMode;
            SettingsF.MagicToggle.Checked = CurrentSettings.MagicGradient;
            SettingsF.InsiderSelect.Enabled = SettingsF.InsiderToggle.Checked;

            MainForm.Instance.Text = CurrentSettings.InsiderMode ? "Onix Launcher (Insider Mode)" : "Onix Launcher";
            MainForm.Instance.TitleText.Text = MainForm.Instance.Text;

            SelectedPath = CurrentSettings.DLLPath;

            Log.Write("Settings updated");
        }

        public static void OpenFile()
        {
            if (!_init)
            {
                _fileDialog = new OpenFileDialog
                {
                    Title = "Select DLL",
                    Multiselect = false,
                    Filter = "DLL files (*.dll)|*.dll" // NOT localizable, thanks rider
                };

                _init = true;
                _fileDialog.FileOk += FileDialogOnFileOk;
            }

            _fileDialog.ShowDialog();
            Log.Write("User selected a custom DLL");
        }

        public static void OpenGame()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "explorer.exe",
                Arguments = "shell:appsFolder\\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App",
            };
            process.StartInfo = startInfo;
            process.Start();
            Log.Write("Attempted to open Minecraft");
        }

        public static bool IsGameOpen()
        {
            Process[] mc = Process.GetProcessesByName("Minecraft.Windows");
            return mc.Length > 0;
        }

        private static void FileDialogOnFileOk(object sender, CancelEventArgs e)
        {
            var customPath = OnixPath + "\\Custom.dll";
            File.Copy(_fileDialog.FileName, customPath, true);

            SelectedPath = customPath;
            CurrentSettings.DLLPath = customPath;
            UpdateSettings();

            Log.Write("Selected DLL: " + customPath);
        }

        public static string GetXboxGamertag()
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var xboxName = "nobody (HOW)";

            if (File.Exists(OnixPath + "\\XboxLiveGamer.xml.txt"))
                File.Delete(OnixPath + "\\XboxLiveGamer.xml.txt");
            if (!File.Exists(
                localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml")) return xboxName;
            try
            {
                File.Copy(localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml",
                    OnixPath + "\\XboxLiveGamer.xml.txt");
                foreach (var readAllLine in File.ReadAllLines(OnixPath + "\\XboxLiveGamer.xml.txt"))
                {
                    if (readAllLine.Contains("Gamertag"))
                        xboxName = readAllLine;
                }
                xboxName = xboxName.Replace("\"Gamertag\"", "");
                xboxName = xboxName.Replace("\"", "");
                xboxName = xboxName.Replace(": ", "");
                xboxName = xboxName.Replace(",", "");
                xboxName = xboxName.Trim();
            }
            catch (ArgumentException e)
            {
                Log.Write("Failed to grab Xbox Gamertag: " + e.Message);
                ShowMessage("Gamertag Error",
                    File.Exists(localappdata +
                                "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml")
                        ? "Xbox info is unavailable at this time. Try again in an hour or so."
                        : "Couldn't get your Xbox Gamertag. Make sure you're signed in to Xbox Live.");
            }

            // you people are funny
            File.Delete(OnixPath + "\\XboxLiveGamer.xml.txt");

            return xboxName;
        }

        public static string GetArchitecture()
        {
            if (CachedArchitecture != "") return CachedArchitecture;
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript(
                    "Get-AppPackage -name Microsoft.MinecraftUWP | select -expandproperty Architecture");
                powerShell.AddCommand("Out-String");
                var psOutput2 = powerShell.Invoke();
                var stringBuilder2 = new StringBuilder();
                foreach (var pSObject in psOutput2)
                    stringBuilder2.AppendLine(pSObject.ToString());

                var arch = stringBuilder2.ToString().Replace(Environment.NewLine, "");
                powerShell.Dispose();
                Log.Write("Got Minecraft's architecture successfully: " + arch);
                CachedArchitecture = arch;
                return arch;
            }
        }

        public static string GetVersion()
        {
            if (CachedVersion != "") return CachedVersion;
            using (var powerShell = PowerShell.Create())
            {
                powerShell.AddScript("Get-AppPackage -name Microsoft.MinecraftUWP | select -expandproperty Version");
                powerShell.AddCommand("Out-String");
                var psOutput = powerShell.Invoke();
                var stringBuilder = new StringBuilder();
                foreach (var pSObject in psOutput)
                    stringBuilder.AppendLine(pSObject.ToString());
                var version = stringBuilder.ToString().Replace(Environment.NewLine, "");
                powerShell.Dispose();
                Log.Write("Got Minecraft version " + version);
                CachedVersion = version;
                return version;
            }
        }
    }
}