using RouletteGameAPI.DTOs.Roulette;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Interfaces.Repositories
{
    public interface IRouletteRepository
    {
        Task<List<Roulette>> GetAllAsync();
        Task<Roulette?> GetByIdAsync(int id);
        Task<Roulette> CreateAsync();
        Task<Roulette?> UpdateAsync(UpdateRouletteGameRequestDTO updateRouletteRequestDTO);
        Task<bool> RouletteExists(int id);
    }
}
