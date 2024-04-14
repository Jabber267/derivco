namespace RouletteGameAPI.Classes
{
    public static class RouletteGame
    {
        public static int Spin()
        {
            return new Random().Next(0,36);
        }
    }
}
