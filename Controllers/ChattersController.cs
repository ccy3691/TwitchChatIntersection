using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchIntersection.Models;
using Microsoft.AspNetCore.Mvc;
using TwitchLib.Api.Core.Models.Undocumented.Chatters;


namespace TwitchIntersection.Controllers
{
    [Route("api/[controller]")]
    public class ChattersController : Controller
    {
        private readonly ITwitchService twitchService;

        public ChattersController(ITwitchService service)
        {
            twitchService = service;
        }

        // GET api/values/5
        [HttpGet("{channelName}")]
        public List<string> Get(string channelName)
        {
            return twitchService.GetChatters(channelName);
        }

        // POST api/values
        [HttpPost("intersect")]
        public List<string> Post([FromBody]ChattersReq value)
        {
            return twitchService.GetChattersIntersect(value.channels);
        }
    }
}
