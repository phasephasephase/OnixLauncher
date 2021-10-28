using System;
using DiscordRPC;

namespace OnixLauncher
{
    public class RichPresence
    {
        public DiscordRpcClient Client;
        private string _discordTime = "";
        
        public RichPresence()
        {
            var TimestampStart = 0;
            var TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            Client = new DiscordRpcClient("845463201550434344");
            Client.Initialize();
            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = "Ready to play",

                Assets = new Assets
                {
                    LargeImageKey = DateTime.Today.Month == 10 ? "onix-halloween" : "onix",
                    LargeImageText = "Onix Launcher"
                },
                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart) ? 
                        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart) : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }

        public void ChangePresence(string server, string version, string gamertag)
        {
            int TimestampStart = 0;
            int TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            string smallimage = "minecraft";
            if (!server.Contains("In a world:") || server != "In the menus" || !server.Contains("."))
            {
                smallimage = server.Contains("The Hive") ? "hive" : server.Split(' ')[2].ToLower();
            }

            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = server,
                State = "as " + gamertag,

                Assets = new Assets
                {

                    LargeImageKey = DateTime.Today.Month == 10 ? "onix-halloween" : "onix",
                    LargeImageText = "Onix Client",
                    SmallImageKey = smallimage,
                    SmallImageText = version
                },
                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart) ? 
                        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart) : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }

        public void ResetPresence()
        {
            int TimestampStart = 0;
            int TimestampEnd = 0;
            dynamic dateTimestampEnd = null;

            if (_discordTime != "" && int.TryParse(_discordTime, out TimestampEnd))
                dateTimestampEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(TimestampEnd);

            Client.SetPresence(new DiscordRPC.RichPresence
            {
                Details = "Ready to play",

                Assets = new Assets
                {
                    LargeImageKey = DateTime.Today.Month == 10 ? "onix-halloween" : "onix",
                    LargeImageText = "Onix Launcher",
                },
                Timestamps = new Timestamps
                {
                    Start = _discordTime != "" && int.TryParse(_discordTime, out TimestampStart) ? 
                        new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                            .AddSeconds(TimestampStart) : DateTime.UtcNow,
                    End = dateTimestampEnd
                }
            });
        }
    }
}