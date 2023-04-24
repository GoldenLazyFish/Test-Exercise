using ClientApiDotNet7.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace ClientApiDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private static List<Client> Clients = new List<Client> {
                new Client
                {
                    Id = 1,
                    FirstName = "Martin",
                    LastName = "Wolfe",
                    Birthday = "2000-01-01",
                    Email = "widderemafra-9766@yopmail.com",
                    Phone = "7(462)871-26-77",
                    Address = "40103 Zulauf Hills Robertaport"
                },
                new Client
                {
                    Id = 2,
                    FirstName = "Gordon",
                    LastName = "Nash",
                    Birthday = "2002-02-02",
                    Email = "waucroiproddopa-1181@yopmail.com",
                    Phone = "7(549)405-16-77",
                    Address = "3899 Rohan Trafficway New August"
                },
                new Client
                {
                    Id = 3,
                    FirstName = "Catherine",
                    LastName = "Perry",
                    Birthday = "2004-04-04",
                    Email = "paucifesasau-8545@yopmail.com",
                    Phone = "7(819)349-74-19",
                    Address = "82339 Nikolas Mill Jaidenshire"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAllClients()
        {
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetSingleClients(int id)
        {
            var user = Clients.Find(x => x.Id == id);
            if(user == null)
                {
                return NotFound("There is no such client");
                }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client user)
        {
            Clients.Add(user);
            return Ok(Clients);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Client>>> UpdateClient(int id, Client request)
        {
            var user = Clients.Find(x => x.Id == id);
            if (user == null)
            {
                return NotFound("There is no such client");
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Address = request.Address;
            user.Birthday = request.Birthday;

            return Ok(Clients);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> DeleteClient(int id)
        {
            var user = Clients.Find(x => x.Id == id);
            if (user == null)
            {
                return NotFound("There is no such client");
            }
            Clients.Remove(user);
            return Ok(Clients);
        }
    }
}
