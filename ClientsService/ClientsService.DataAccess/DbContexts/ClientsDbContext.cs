using ClientsService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientsService.DataAccess.DbContexts
{
    public class ClientsDbContext : DbContext
    {
        public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}