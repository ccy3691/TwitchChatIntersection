using System;
using TwitchLib.Api.Core.Models.Undocumented.Chatters;
using System.Collections.Generic;
using TwitchLib.Api;
using System.Linq;
using TwitchLib.Api.Helix.Models.Users;
using TwitchLib.Api.V5.Models.Subscriptions;
using TwitchLib.Api.Core.Undocumented;
using System.Threading.Tasks;

namespace TwitchIntersection
{
    public class TwitchService : ITwitchService
    {
        TwitchAPI api;
        public TwitchService()
        {
            System.Console.WriteLine("Initializing Twitch Service API...");
            Init();
            System.Console.WriteLine("Twitch Service API Initialized");

        }

        private void Init()
        {
            api = new TwitchAPI();
            api.Settings.ClientId = "gp762nuuoqcoxypju8c569th9wz7q5";
            api.Settings.AccessToken = "yy7p2h3tdk6dbauv41g0ltiq8nmpt8";
        }

        public List<string> GetChatters(string channelName)
        {
            Task<List<ChatterFormatted>> chatters = api.Undocumented.GetChattersAsync(channelName);
            return chatters.Result.Select(i => i.Username).ToList();
        }

        public List<string> GetChattersIntersect(string[] channels)
        {
            List<string> list = GetChatters(channels[0]);
            channels = channels.Skip(1).ToArray();
            foreach (var channel in channels)
            {
                List<string> currChannelList = GetChatters(channel);
                list.RemoveAll(i => !currChannelList.Contains(i));
            }
            return list;
        }

    }
}
