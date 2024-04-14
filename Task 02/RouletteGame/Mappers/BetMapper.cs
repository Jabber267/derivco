using Microsoft.AspNetCore.Http.HttpResults;
using RouletteGameAPI.DTOs.Bet;
using RouletteGameAPI.Models;

namespace RouletteGameAPI.Mappers
{
    public static class BetMapper
    {
        public static BetDTO ToBetDTO(this Bet bet)
        {
            return new BetDTO
            {
                BetId = bet.BetId,
                RouletteId = bet.RouletteId,
                Amount = bet.Amount,
                PutOn = bet.PutOn,
                Payout = bet.Payout
            };
        }

        public static Bet ToBetFromCreateDTO(this CreateBetRequestDTO betDTO)
        {
            return new Bet
            {
                RouletteId = betDTO.RouletteId,
                Amount = betDTO.Amount,
                PutOn = betDTO.PutOn
            };
        }
    }
}
