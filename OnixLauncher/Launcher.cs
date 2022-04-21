using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using Guna.UI2.WinForms;

namespace OnixLauncher
{
    public static class Launcher
    {
        public static Guna2GradientButton LaunchButton;
        public static Guna2ProgressBar LaunchProgress;
        public static System.Timers.Timer PresenceTimer;

        public static void Launch()
        {
            Utils.ShowMessage("weird", "bug fix");
            Utils.MessageF.Hide(); // gotta show this once to make it work

            // let's try this instead
            if (File.Exists(Utils.DLLPath) && !Utils.IsGameOpen())
                File.Delete(Utils.DLLPath);

            if (Utils.SelectedPath == "no file" && Utils.CurrentSettings.InsiderMode)
            {
                Utils.ShowMessage("Insider Mode", "Select an Onix Client DLL first!\n  ");
                return;
            }

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

                    if (!supported && !Utils.CurrentSettings.InsiderMode)
                    {
                        Log.Write("The user isn't on a supported version");
                        LaunchButton.Enabled = true;
                        LaunchProgress.Visible = false;
                        Utils.ShowMessage("Unsupported Version",
                            "Your version (" + version + ") is not supported by Onix Client.");
                    }
                    else
                    {
                        if (!supported && Utils.CurrentSettings.InsiderMode)
                        {
                            Log.Write("Incorrect version, but was bypassed. Launching...");
                        }
                        else if (supported)
                        {
                            Log.Write("Correct Version, Launching...");
                        }

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

                            if (Utils.CurrentSettings.InsiderMode && Utils.SelectedPath != "no file")
                                Injector.Inject(Utils.SelectedPath);
                            else
                                Injector.Inject(dllPath);

                            LaunchProgress.Value = LaunchProgress.Maximum;

                            RichPresence.ChangePresence("In the menus", Utils.GetVersion(), Utils.GetXboxGamertag());
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
    }
}
