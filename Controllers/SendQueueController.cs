using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace queue.Controllers
{
    [Route("api/[controller]")]
    public class SendQueueController : Controller
    {
        [HttpPost]
        public void SendQueue([FromBody]string body){
            Queue.Services.SendQueue queue =new Queue.Services.SendQueue();
            queue.SendMessage();
        }
    }
}