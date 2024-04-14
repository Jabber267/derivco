using Microsoft.EntityFrameworkCore;
using RouletteGameAPI.Databases;
using RouletteGameAPI.DTOs.Bet;
using RouletteGameAPI.Interfaces.Repositories;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Repositories
{
    public class BetRepository(ApiDbContext context) : IBetRepository
    {
        private readonly ApiDbContext _context = context;

        public async Task<List<Bet>> GetAllAsync()
        {
            return await _context.Bet.ToListAsync();
        }

        public async Task<Bet?> GetByIdAsync(int id)
        {
            return await _context.Bet.FirstOrDefaultAsync(x => x.BetId == id);
        }

        public async Task<Bet?> CreateAsync(Bet bet)
        {
            var rouletteExists = _context.Roulette.Any(r => r.Id == bet.RouletteId);
            if (!rouletteExists) return null;

            await _context.Bet.AddAsync(bet);
            await _context.SaveChangesAsync();

            return bet;
        }

        public async Task<List<Bet>?> PayoutBetsAsync(UpdateBetRequestDTO updateBetRequestDTO)
        {
            var roulleteGame = await _context.Roulette.FirstOrDefaultAsync(x => x.Id == updateBetRequestDTO.RouletteId);
            if (roulleteGame == null) return null;

            var existingBets = await _context.Bet.Where(x => x.RouletteId == updateBetRequestDTO.RouletteId).ToListAsync();
            if (existingBets.Count == 0) return null;

            foreach (var existingBet in existingBets)
            {
                if(existingBet.PutOn == roulleteGame.WinningNumber)
                    existingBet.Payout = existingBet.Amount * 2.5m; // static winning multiplier since we only have bet rule.
            }

            await _context.SaveChangesAsync();

            return existingBets;
        }

        public async Task<bool> BetExists(int id)
        {
            return await _context.Bet.AnyAsync(x => x.BetId == id);
        }
    }
}
