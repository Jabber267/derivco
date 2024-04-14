using System.ComponentModel.DataAnnotations.Schema;

namespace RouletteGameAPI.DTOs.Bet
{
    public class BetDTO
    {
        public int BetId { get; set; }
        public int RouletteId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } = decimal.Zero;
        public int PutOn { get; set; } = -1;
        public decimal Payout { get; set; } = decimal.Zero;
    }
}
