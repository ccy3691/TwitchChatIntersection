using TwitchLib.Api.Core.Models.Undocumented.Chatters;
using System;
using System.Collections.Generic;

public interface ITwitchService
{
    List<string> GetChatters(string channelName);

    List<string> GetChattersIntersect(string[] channels);

}