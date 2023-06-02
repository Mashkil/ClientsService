using ClientsService.Application.Models;
using ClientsService.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsService clientsService;

        public ClientController(IClientsService clientsService)
        {
            this.clientsService = clientsService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(500)]
        public async Task<Guid> Create(ClientDTO client)
        {
            return await clientsService.Create(client);
        }

        [HttpGet("isExisting/{id}")]
        [ProducesResponseType(typeof(bool),200)]
        [ProducesResponseType(500)]
        public async Task<bool> IsExisting(Guid id)
        {
            return await clientsService.IsExisting(id);
        }
    }
}
