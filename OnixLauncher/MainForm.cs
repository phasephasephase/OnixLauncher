using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace OnixLauncher
{
    public partial class MainForm : Form
    {
        public static Form Instance;
        private RichPresence _presence;
        public static bool Bypassed;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }

        public MainForm()
        {
            // init
            Log.Write("Initializing UI");
            InitializeComponent();
            Log.Write("Initialized UI");
            Instance = this;
            _presence = new RichPresence();

            // We want to have the form in the middle to polish everything
            StartPosition = FormStartPosition.CenterScreen;

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
            FadeTimer.Start();
            Log.Write("Exiting...");
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
            Utils.ShowMessage("Credits", 
                "Onix Client - by Onix86\nOnix Launcher - by carlton (and all of the contributors on GitHub <3)");
        }

        private void Discord_Click(object sender, EventArgs e)
        {
            string url = "https://discord.com/invite/onixclient";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
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
            LaunchProgress.Visible = false;
            LaunchButton.Enabled = true;
            Log.Write("Finished launching");
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            Utils.ShowMessage("weird", "bug fix");
            Utils.MessageF.Hide(); // gotta show this once to make it work

            // let's try this instead
            if (File.Exists(Utils.DLLPath) && !Utils.IsGameOpen())
                File.Delete(Utils.DLLPath);

            try
            {
                Log.Write("Preparing to launch");
                // let's go!
                LaunchButton.Enabled = false;
                LaunchProgress.Visible = true;

                LaunchProgress.Value = 0;
                LaunchProgress.Maximum = int.MaxValue;

                BackgroundWorker bw = new BackgroundWorker();

                bw.DoWork += new DoWorkEventHandler(delegate (object o, DoWorkEventArgs workerE)
                {
                    var versionClient = new WebClient();
                    var dllClient = new WebClient();
                    var dllPath = Utils.DLLPath;

                    dllClient.DownloadProgressChanged += 
                        new DownloadProgressChangedEventHandler((object s, DownloadProgressChangedEventArgs ez) =>
                    {
                        long bytesIn = ez.BytesReceived;
                        long totalBytes = ez.TotalBytesToReceive;

                        double value = ((double)bytesIn / (double)totalBytes) * (LaunchProgress.Maximum / 70);

                        LaunchProgress.Value += (int)value;
                    });

                    // architecture detection
                    var arch = Utils.GetArchitecture();
                    LaunchProgress.Value += LaunchProgress.Maximum / 10;

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
                    LaunchProgress.Value += LaunchProgress.Maximum / 10;

                    Log.Write("Downloading list of supported versions");

                    var latestSupported = versionClient.DownloadString(
                        "https://raw.githubusercontent.com/bernarddesfosse/onixclientautoupdate/main/LatestSupportedVersion");

                    versionClient.Dispose();

                    Log.Write("Downloaded, comparing versions");
                    List<string> stringTable = latestSupported.Split('\n').ToList();
                    var supported = stringTable.Contains(version);

                    //version = "eaghruyehruger"; // test

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
                        if (!supported && Bypassed)
                            Log.Write("Incorrect version, but was bypassed. Launching...");
                        else if (supported)
                            Log.Write("Correct Version, Launching...");

                        BackgroundWorker injector = new BackgroundWorker();

                        injector.DoWork += new DoWorkEventHandler(delegate (object ins, DoWorkEventArgs ina)
                        {
                            Log.Write("Preparing to inject into the game");

                            BackgroundWorker staticProgress = new BackgroundWorker();

                            staticProgress.DoWork += new DoWorkEventHandler((object sts, DoWorkEventArgs sta) =>
                            {
                                while (true)
                                {
                                    if (LaunchProgress.Value >= ((LaunchProgress.Maximum / 100) * 95)) break;
                                    LaunchProgress.Value += (LaunchProgress.Maximum / 100);
                                    Thread.Sleep(100);
                                }
                            });

                            staticProgress.RunWorkerAsync();

                            if (Bypassed && Utils.SelectedPath != "no file")
                                Injector.Inject(Utils.SelectedPath);
                            else
                                Injector.Inject(dllPath);

                            LaunchProgress.Value = LaunchProgress.Maximum;

                            _presence.ChangePresence("In the menus", Utils.GetVersion(), Utils.GetXboxGamertag());
                            PresenceTimer.Start();

                            dllClient.Dispose();
                        });

                        dllClient.DownloadFileCompleted += 
                            new AsyncCompletedEventHandler((object dls, AsyncCompletedEventArgs dla) =>
                        {
                            injector.RunWorkerAsync();
                        });

                        if (Utils.IsGameOpen())
                        {
                            LaunchProgress.Maximum /= 3;
                            injector.RunWorkerAsync();
                        }
                        else if (!File.Exists(dllPath))
                            dllClient.DownloadFileAsync(
                                new Uri("https://github.com/bernarddesfosse/onixclientautoupdate/raw/main/OnixClient.dll"), dllPath);
                    }
                    });

                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                Log.Write("We ran into a problem while launching: " + ex.Message);
                Utils.ShowMessage("Launch Error", $"Failed to launch Onix Client. Check the logs for info. \n({Log.LogPath})");
            }
        }

        private List<string> _previousServers = new List<string>() { "" }; // ok
        private bool _once;

        private void ChangeServer()

        {
            string currentServer = string.Empty;
            try
            {
                currentServer = File.ReadAllText(Utils.RPCServerPath);
            }
            catch
            {
                if (!_once)
                {
                    Log.Write("Ran into a problem with server.txt (most likely doesn't exist)");
                    _once = true;
                }
            }

            if (!_once)
            {
                if (_previousServers[_previousServers.Count - 1] == currentServer) return;
                _previousServers.Add(currentServer);
                if (_previousServers.Count > 5) _previousServers.RemoveAt(0);
                Log.Write("Detected a change in server.txt, updating presence");

                if (currentServer == "")
                    _presence.ChangePresence("In the menus", Utils.GetVersion(), Utils.GetXboxGamertag());
                else if (currentServer.Contains("In a World, "))
                    _presence.ChangePresence("In a world: " + currentServer.Remove(0, 12), Utils.GetVersion(),
                        Utils.GetXboxGamertag());
                else
                {
                    switch (currentServer)
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

                        case "zeqa.net":
                        case "51.222.245.157": // na ip's
                        case "66.70.181.97":
						case "651.222.244.138": 
						case "51.210.223.196": // eu ip's
						case "164.132.200.60":
						case "51.210.223.195":
						case "51.79.163.9": // as ip's
						case "139.99.120.127":
						case "51.79.177.168":
						case "51.79.162.196":
                            _presence.ChangePresence("Playing on Zeqa", Utils.GetVersion(), Utils.GetXboxGamertag());
                            break;
							
                        case "rushnation.net":
                            _presence.ChangePresence("Playing on RushNation", Utils.GetVersion(), Utils.GetXboxGamertag());
                            break;
                        
                        default:
                            _presence.ChangePresence("Playing on " + currentServer, Utils.GetVersion(), Utils.GetXboxGamertag());
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

        private float _fadeSpeed = 0.06f; // Must be a positive float

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (_fadeSpeed > 0)
            {
                if (Opacity >= 1)
                {
                    FadeTimer.Stop();
                    _fadeSpeed *= -1;
                    return;
                }
            }
            else
            {
                if (Opacity <= 0)
                {
                    FadeTimer.Stop();
                    Log.Write("bye");
                    Close();
                    return;
                }
            }

            Opacity += _fadeSpeed;
        }
    }
}