namespace RouletteGameAPI.DTOs.Bet
{
    public class CreateBetRequestDTO
    {
        public int RouletteId { get; set; }
        public decimal Amount { get; set; } = decimal.Zero;
        public int PutOn { get; set; } = -1;
    }
}
