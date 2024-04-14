namespace RouletteGameAPI.Models
{
    public class Roulette
    {
        public int Id { get; set; }
        public int WinningNumber { get; set; } = -1;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
