using eTickets.Models;

namespace eTickets.Services.Interfaces
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetById(int id);
        Task<bool> Create(Actor actor);
        Task<Actor> Update(Actor actor);
        Task<bool> Delete(int id);
    }
}
