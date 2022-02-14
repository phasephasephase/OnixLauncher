using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Timers;

namespace OnixLauncher
{
    public partial class MainForm : Form
    {
        public static Form Instance;
        private RichPresence _presence;
        public static bool Bypassed;

        public MainForm()
        {
            // init
            Log.Write("Initializing UI");
            InitializeComponent();
            Log.Write("Initialized UI");
            Instance = this;
            _presence = new RichPresence();
            
            // create directories
            Directory.CreateDirectory(Utils.OnixPath);
            Directory.CreateDirectory(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\RoamingState\OnixClient\Launcher");
            
            // stupid winforms thing that fixes message boxes
            CheckForIllegalCrossThreadCalls = false;

            // this is a bit useless, might remove soon
            Injector.InjectionCompleted += InjectionCompleted;

            // first time?
            if (!File.Exists(Utils.OnixPath + "\\firstTime"))
            {
                Log.Write("Detected first time open, showing the welcome message box");
                File.Create(Utils.OnixPath + "\\firstTime");
                Utils.ShowMessage("Welcome to Onix Client!", 
                    "Check our Discord's #faq channel if you're having problems.");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Log.Write("Exiting");
            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            Log.Write("Minimizing the launcher");
            WindowState = FormWindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Winapi.ReleaseCapture();
            Winapi.SendMessage(Handle, Winapi.WM_NCLBUTTONDOWN, Winapi.HT_CAPTION, 0);
        }

        private void CreditsButton_Click(object sender, EventArgs e)
        {
            Utils.ShowMessage("Credits", "Onix Client - by Onix86\nOnix Launcher - by carlton");
        }

        private void Discord_Click(object sender, EventArgs e)
        {
            String url = "https://discord.com/invite/onixclient";
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = url, UseShellExecute = true
            });
        }

        private void BigOnixLogo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Bypassed)
            {
                Log.Write("The user enabled Insider Mode");
                Utils.OpenFile();
            }
            else
            {
                Log.Write("The user disabled Insider Mode");
                Utils.ShowMessage("Insider Mode", "Your DLL was set back to the release version.");
            }
        }

        private void InjectionCompleted(object sender, EventArgs e)
        {
            LaunchButton.Enabled = true;
            LaunchProgress.Visible = false;
            Log.Write("Finished launching");
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            Utils.ShowMessage("weird", "bug fix");
            Utils.MessageF.Hide(); // gotta show this once to make it work
            try
            {
                Log.Write("Preparing to launch");
                // let's go!
                LaunchButton.Enabled = false;
                LaunchProgress.Visible = true;

                var injectThread = new Thread(() =>
                {
                    var injectClient = new WebClient();
                    var dllPath = Utils.OnixPath + "\\OnixClient.dll";

                    // architecture detection
                    var arch = Utils.GetArchitecture();

                    if (arch == string.Empty)
                    {
                        Log.Write("Launcher couldn't detect the game, either it's not installed or the user has a cracked version");
                        // wtf the game not installed
                        Utils.ShowMessage("????????", "You don't even have Minecraft Bedrock installed!");
                        LaunchButton.Enabled = true;
                        LaunchProgress.Visible = false;
                        return;
                    }
                    
                    if (arch != "X64")
                    {
                        Log.Write("This doesn't seem like the correct architecture we want");
                        Utils.ShowMessage("Architecture Error", "You have a version of Minecraft that isn't 64-bit.");
                        LaunchButton.Enabled = true;
                        LaunchProgress.Visible = false;
                        return;
                    }

                    // version detection
                    var version = Utils.GetVersion();
                    Log.Write("Downloading list of supported versions");
                    var latestSupported = injectClient.DownloadString(
                        "https://raw.githubusercontent.com/bernarddesfosse/onixclientautoupdate/main/LatestSupportedVersion");
                    Log.Write("Downloaded, comparing versions");
                    var stringTable = latestSupported.Split('\n');
                    var supported = false;

                    //version = "eaghruyehruger"; // test

                    foreach (var ver in stringTable)
                    {
                        if (version == ver)
                            supported = true;
                    }

                    if (!supported && !Bypassed)
                    {
                        Log.Write("The user isn't on a supported version");
                        LaunchButton.Enabled = true;
                        LaunchProgress.Visible = false;
                        Utils.ShowMessage("Unsupported Version",
                            "Your version (" + version + ") is not supported by Onix Client.");
                    }
                    else
                    {
                        Log.Write("This is either the right version or Insider Mode was enabled, launching");
                        if (File.Exists(dllPath) && Process.GetProcessesByName("Minecraft.Windows").Length == 0)
                            File.Delete(dllPath);

                        if (!File.Exists(dllPath))
                            injectClient.DownloadFile(
                                "https://github.com/bernarddesfosse/onixclientautoupdate/raw/main/OnixClient.dll",
                                dllPath);
                        Log.Write("Got DLL, preparing to inject into the game");

                        if (Bypassed && Utils.SelectedPath != "no file")
                            Injector.Inject(Utils.SelectedPath);
                        else
                            Injector.Inject(dllPath);

                        _presence.ChangePresence("In the menus", Utils.GetVersion(), Utils.GetXboxGamertag());
                        PresenceTimer.Start();
                    }
                    
                    injectClient.Dispose(); // HOLY SHIT!!!!
                });
                injectThread.Start();
            }
            catch (Exception ex)
            {
                Log.Write("We ran into a problem while launching: " + ex.Message);
                Utils.ShowMessage("Launch Error", "Failed to launch Onix Client. Check the logs for info.");
            }
        }

        private string _previousServer; // ok
        private bool _once;

        private void ChangeServer()
        {
            try
            {
                _previousServer = File.ReadAllText(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                    + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\RoamingState\OnixClient\Launcher\server.txt");
            }
            catch
            {
                if (!_once)
                {
                    // Utils.ShowMessage("RPC Error", "Discord Rich presence is currently unavailable."); shit error, replacing with log
                    Log.Write("Ran into a problem with server.txt (most likely doesn't exist)");
                    _once = true;
                }
            }

            if (!_once)
            {
                var server = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                                          + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\RoamingState\OnixClient\Launcher\server.txt");
            if (server == _previousServer) return;
            _previousServer = server;
            Log.Write("Detected a change in server.txt, updating presence");

            if (server == "")
                _presence.ChangePresence("In the menus", Utils.GetVersion(), Utils.GetXboxGamertag());
            else if (server.Contains("In a World, "))
                _presence.ChangePresence("In a world: " + server.Remove(0, 12), Utils.GetVersion(),
                    Utils.GetXboxGamertag());
            else
            {
                switch (server)
                {
                    case "geo.hivebedrock.network":
                    case "fr.hivebedrock.network":
                    case "ca.hivebedrock.network":
                    case "sg.hivebedrock.network":
                    case "jp.hivebedrock.network":
                        _presence.ChangePresence("Playing on The Hive", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "play.inpvp.net":
                        _presence.ChangePresence("Playing on Mineville", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "mco.cubecraft.net":
                        _presence.ChangePresence("Playing on CubeCraft", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "mco.mineplex.com":
                        _presence.ChangePresence("Playing on Mineplex", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "play.galaxite.net":
                        _presence.ChangePresence("Playing on Galaxite", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "mco.lbsg.net":
                        _presence.ChangePresence("Playing on Lifeboat", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "play.nethergames.org":
                        _presence.ChangePresence("Playing on NetherGames", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    case "play.hyperlandsmc.net":
                        _presence.ChangePresence("Playing on HyperLands", Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                    default:
                        _presence.ChangePresence("Playing on " + server, Utils.GetVersion(), Utils.GetXboxGamertag());
                        break;
                }
            }
            }
        }

        private void PresenceTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var minecraftIndex = Process.GetProcessesByName("Minecraft.Windows");

            if (minecraftIndex.Length == 0)
            {
                Log.Write("Minecraft seems like it was closed");
                _presence.ResetPresence();
                PresenceTimer.Stop();
            }
            else
            {
                ChangeServer();
            }
        }
    }
}