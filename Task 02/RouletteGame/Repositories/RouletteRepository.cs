using Microsoft.EntityFrameworkCore;
using RouletteGameAPI.Classes;
using RouletteGameAPI.Databases;
using RouletteGameAPI.DTOs.Roulette;
using RouletteGameAPI.Interfaces.Repositories;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Repositories
{
    public class RouletteRepository(ApiDbContext context) : IRouletteRepository
    {
        private readonly ApiDbContext _context = context;

        public async Task<List<Roulette>> GetAllAsync()
        {
            return await _context.Roulette.Where(r => r.WinningNumber != -1).ToListAsync();
        }

        public async Task<Roulette?> GetByIdAsync(int id)
        {
            return await _context.Roulette.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Roulette> CreateAsync()
        {
            var result = await _context.Roulette.AddAsync(new Roulette());
            await _context.SaveChangesAsync();

            var roulette = new Roulette() 
            { 
                Id = result.Entity.Id,
                WinningNumber = result.Entity.WinningNumber,
                Created = result.Entity.Created
            };

            return roulette;
        }

        public async Task<Roulette?> UpdateAsync(UpdateRouletteGameRequestDTO updateRouletteRequestDTO)
        {
            var existingRoulette = await _context.Roulette.FirstOrDefaultAsync(x => x.Id == updateRouletteRequestDTO.Id);

            if (existingRoulette == null) return null;

            existingRoulette.WinningNumber = RouletteGame.Spin();

            await _context.SaveChangesAsync();

            return existingRoulette;
        }

        public async Task<bool> RouletteExists(int id)
        {
            return await _context.Roulette.AnyAsync(x => x.Id == id);
        }
    }
}
