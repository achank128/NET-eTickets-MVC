using eTickets.Data;
using eTickets.Models;
using eTickets.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Services.Implements
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context) {
            _context = context;
        }

        public async Task<bool> Create(Actor actor)
        {
            _context.Actors.Add(actor);
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor> GetById(int id)
        {
            var actor = await _context.Actors.SingleOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task<Actor> Update(Actor actor)
        {
            _context.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<bool> Delete(int id)
        {
            var actor = await _context.Actors.SingleOrDefaultAsync(x => x.Id == id);
            if (actor == null)
            {
                return false;
            }
            _context.Actors.Remove(actor);
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
