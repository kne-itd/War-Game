using System;
using War.Objects;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Arne", "Bo");
            while (!game.IsEndOfGame())
            {
                game.PlayTurn();
            }
            Console.Read();
        }
    }
}
