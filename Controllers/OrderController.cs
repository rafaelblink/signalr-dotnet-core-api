using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using TestHubWebApi.Models;

namespace TestHubWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        public static HubConnection _connection;

        public OrderController()
        {   
            if(_connection == null || _connection.State == HubConnectionState.Disconnected) 
            {
                _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();
                _connection.StartAsync();
                _connection.On<Order>("ReceiveOrder", order =>
                {
                    Console.WriteLine(order.ToString());
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            await _connection.InvokeAsync("SendOrder", order);
            return Ok();
        }
    }
}
