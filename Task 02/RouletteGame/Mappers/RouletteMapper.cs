using RouletteGameAPI.DTOs.Roulette;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Mappers
{
    public static class RouletteMapper
    {
        public static RouletteDTO ToRoulleteDTO(this Roulette roulette)
        {
            return new RouletteDTO
            {
                Id = roulette.Id,
                WinningNumber = roulette.WinningNumber,
            };
        }

        public static Roulette ToGameFromCreateDTO(this CreateRouletteGameRequestDTO rouletteDTO)
        {
            return new Roulette
            {
                WinningNumber = rouletteDTO.WinningNumber
            };
        }
    }
}
