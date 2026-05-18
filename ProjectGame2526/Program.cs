namespace ProjectGame2526;

public class Program
{

    static void Main(string[] args)
    {
        // create the game
        Game game = new Game(30, 30);

        // start the game loop
        RunGameLoop(game);
    }

    protected static void RunGameLoop(Game game)
    {
        int refreshRate = 20;

        Console.CursorVisible = false;

        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();

        Reset(game);

        game.Draw();
        Console.SetCursorPosition(0, 0);

        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                game.OnInput(key.Key);
            }

            System.Threading.Thread.Sleep(1000 / refreshRate);

            game.Update((1.0f / (float)refreshRate));

           // Reset(game);
            game.Draw();

        }
    }

    protected static void Reset(Game game)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(0, 0);
        for (int y = 0; y < game.GetHeight(); ++y)
        {
            for (int x = 0; x < game.GetWidth(); ++x)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(0, 0);
    }
}