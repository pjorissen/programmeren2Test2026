using System;
using System.ComponentModel;

namespace ProjectGame2526;

public enum GameState
{
    StartingScreen,
    MainMenu,
    GameRunning,
    GamePaused,
    GameOver,
    GameWon,
    NoGameState,
}

public class Game
{
    protected int width, height;
    protected int playerPosX = 10, playerPosY = 10;
    protected const int enemyDamage = 50;

    protected GameState currentGameState;
    protected GameState previousGameState;

    protected Player player;
    protected Level level;
    protected Enemy enemy;

    protected Screen startingScreen;
    protected Screen gameOverScreen;
    protected Menu mainMenu;
    protected StartGameMenuItem startGameMenuItem;
    protected ExitGameMenuItem exitGameMenuItem;

    public GameState CurrentGameState
    {
        get {return currentGameState;}
        set {currentGameState = value;}
    }

    public Game(int newWidth, int newHeight)
    {
        // set the size
        width = newWidth;
        height = newHeight;

        // set the window
        Console.WindowWidth = width + 1;
        Console.WindowHeight = height + 1;

        currentGameState = GameState.StartingScreen;
        previousGameState = GameState.NoGameState;


        player = new Player(playerPosX, playerPosY, ConsoleColor.Blue, '@');
        level = new Level(width, height);
        enemy = new Enemy(2,2, level);

        startingScreen = new Screen("StartingScreenText.txt");
        gameOverScreen = new Screen("GameOverScreenText.txt");
        mainMenu = new Menu("MainMenuText.txt");
        startGameMenuItem = new StartGameMenuItem();
        exitGameMenuItem = new ExitGameMenuItem();

        mainMenu.AddMenuItem(startGameMenuItem);
        mainMenu.AddMenuItem(exitGameMenuItem);
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public void Draw()
    {
        switch(currentGameState)
        {
            case GameState.StartingScreen:
                if(currentGameState != previousGameState)
                {
                    startingScreen.Draw();
                }
                break;
            case GameState.MainMenu:
                if(currentGameState != previousGameState)
                {
                    mainMenu.Draw();
                }
                break;
            case GameState.GameRunning:
                level.Draw();
                player.Draw();
                enemy.Draw();
                break;
            case GameState.GameOver:
                if(currentGameState != previousGameState)
                {
                    gameOverScreen.Draw();
                }
                break;
        }

        previousGameState = currentGameState;
    }

    public void OnInput(ConsoleKey key)
    {
        switch(currentGameState)
        {
            case GameState.StartingScreen:
                if(key == ConsoleKey.Spacebar)
                {
                    ResetScreen();
                    currentGameState = GameState.MainMenu;
                }
                break;
            case GameState.MainMenu:
                if (key == ConsoleKey.Spacebar)
                {
                    ResetScreen();
                    startGameMenuItem.Activate(this);
                }
                break;
            case GameState.GameRunning:
                if (key == ConsoleKey.LeftArrow)
                {
                    player.Move(-1, 0, width, height);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    player.Move(1, 0, width, height);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    player.Move(0, 1, width, height);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    player.Move(0, -1, width, height);
                }
                break;
            case GameState.GameOver:
                if(key == ConsoleKey.Spacebar)
                {
                    ResetScreen();
                    currentGameState = GameState.MainMenu;
                }
                break;
        }
    }

    public void Update(double dt)
    {
        switch (currentGameState)
        {
            case GameState.StartingScreen:
                break;
            case GameState.GameRunning:
                enemy.Update(dt, width, height);
                HandleCollision();
                break;
        }
    }

    public void HandleCollision()
    {
        //check if colliding with an enemy
        if(enemy.CursorX == player.CursorX && enemy.CursorY == player.CursorY)
        {
            player.DoDamage(enemyDamage, this);
        }
    }

    public void ResetScreen()
    {
        Console.SetCursorPosition(0,0);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Black;
        for(int i= 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.SetCursorPosition(0,0);
    }
}