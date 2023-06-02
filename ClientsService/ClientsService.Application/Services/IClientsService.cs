using ClientsService.Application.Models;

namespace ClientsService.Application.Services
{
    public interface IClientsService
    {
        Task<Guid> Create(ClientDTO client);
        Task<bool> IsExisting(Guid id);
    }
}