using ClientsService.Application.Models;
using ClientsService.DataAccess.DbContexts;
using ClientsService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsService.Application.Services
{
    public class ClientService : IClientsService
    {
        private readonly ClientsDbContext _db;

        public ClientService(ClientsDbContext db)
        {
            _db = db;
        }
        
        public async Task<Guid> Create(ClientDTO client)
        {
            var createdClient = new Client
            {
                Name = client.Name,
                Timestamp = DateTimeOffset.Now
            };

            await _db.Clients.AddAsync(createdClient);
            await _db.SaveChangesAsync();

            return createdClient.Id;
        }

        public async Task<bool> IsExisting(Guid id)
        {
             return await _db.Clients.FirstOrDefaultAsync(c => c.Id == id)!=null;
        }
    }
}
