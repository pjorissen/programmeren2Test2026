using System;

namespace ProjectGame2526;

public class Player : Sprite
{
    protected int health;
    public Player(int newX, int newY, ConsoleColor newColor, char newSymbol) : base(newX, newY, newColor, newSymbol)
    {
        health = 100;
    }

    public int Health
    {
        get { return health; }
    }

    public void DoDamage(int damage, Game game)
    {
        health -= damage;
        if( health <= 0)
        {
            health = 0;
            color = ConsoleColor.Blue;
            game.ResetScreen();
            game.CurrentGameState = GameState.GameOver;
        }
    }
}
