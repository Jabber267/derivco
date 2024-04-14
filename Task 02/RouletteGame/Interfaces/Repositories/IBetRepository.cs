using RouletteGameAPI.DTOs.Bet;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Interfaces.Repositories
{
    public interface IBetRepository
    {
        Task<List<Bet>> GetAllAsync();
        Task<Bet?> GetByIdAsync(int id);
        Task<Bet?> CreateAsync(Bet bet);
        Task<List<Bet>?> PayoutBetsAsync(UpdateBetRequestDTO updateBetRequestDTO);
        Task<bool> BetExists(int id);
    }
}
