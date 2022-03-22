using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Text;
using System.Windows.Forms;

namespace OnixLauncher
{
    public static class Utils
    {
        public static string OnixPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                        @"\Onix Launcher";

        public static string RPCServerPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                          + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\RoamingState\OnixClient\Launcher\server.txt";

        public static string DLLPath = OnixPath + @"\OnixClient.dll";

        private static OpenFileDialog _fileDialog;
        private static bool _init;
        public static string SelectedPath = "no file";
        public static MessageForm MessageF = new MessageForm("you shouldn't see this", "how are you reading this");

        public static void ShowMessage(string title, string subtitle)
        {
            Log.Write("Showing a message box: " + title);
            MessageF.SetTitleAndSubtitle(title, subtitle);
            MessageF.Owner = MainForm.Instance;
            MessageF.Show();
        }

        public static void OpenFile()
        {
            if (!_init)
            {
                _fileDialog = new OpenFileDialog();
                _fileDialog.Title = "Select DLL";
                _fileDialog.Multiselect = false;
                _fileDialog.Filter = "DLL files (*.dll)|*.dll"; // NOT localizable, thanks rider
                _init = true;
                _fileDialog.FileOk += FileDialogOnFileOk;
            }

            _fileDialog.ShowDialog();
            Log.Write("User is selecting a custom DLL");
        }

        public static void OpenGame()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "explorer.exe",
                Arguments = "shell:appsFolder\\Microsoft.MinecraftUWP_8wekyb3d8bbwe!App"
            };
            process.StartInfo = startInfo;
            process.Start();
            Log.Write("Opened Minecraft, or at least I tried to");
        }

        public static bool IsGameOpen()
        {
            Process[] mc = Process.GetProcessesByName("Minecraft.Windows");
            return mc.Length > 0;
        }

        private static void FileDialogOnFileOk(object sender, CancelEventArgs e)
        {
            SelectedPath = _fileDialog.FileName;
            MainForm.Bypassed = true;
            Log.Write("Selected DLL: " + SelectedPath);
            ShowMessage("Insider Mode", "This is intended to be used with Onix DLLs only.");
        }

        public static string GetXboxGamertag()
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var xboxName = "Not signed in (silly)";

            if (File.Exists(OnixPath + "\\XboxLiveGamer.xml.txt"))
                File.Delete(OnixPath + "\\XboxLiveGamer.xml.txt");
            if (!File.Exists(
                localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml")) return xboxName;
            try
            {
                File.Copy(localappdata + "\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe\\LocalState\\XboxLiveGamer.xml", OnixPath + "\\XboxLiveGamer.xml.txt");
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

            return xboxName;
        }

        public static string GetArchitecture()
        {
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
                return arch;
            }
        }

        public static string GetVersion()
        {
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
                return version;
            }
        }
    }
}