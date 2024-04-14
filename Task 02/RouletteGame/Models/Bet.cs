using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameAPI.Models
{
    public class Bet
    {
        public int BetId { get; set; }
        public int RouletteId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = decimal.Zero;

        // Keeping it simple with only single number bets
        public int PutOn { get; set; } = -1;
        public decimal Payout { get; set; } = decimal.Zero;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}