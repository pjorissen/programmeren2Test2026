using System;
using System.Diagnostics.Contracts;

namespace ProjectGame2526;

public class Sprite
{
    protected double x;
    protected double y;

    protected ConsoleColor color;

    protected char symbol;

    public double X
    {
        get{return x;}
        set{x = value;}
    }

    public double Y
    {
        get{return y;}
        set{y = value;}
    }

    public int CursorX
    {
        get{return Convert.ToInt32(x);}
    }

    public int CursorY
    {
        get{return Convert.ToInt32(y);}
    }

    public ConsoleColor Color
    {
        get{return color;}
        set{color = value;}
    }    

    public char Symbol
    {
        get{return symbol;}
        set{symbol = value;}
    }

    public Sprite(int newX, int newY, ConsoleColor newColor, char newSymbol)
    {
        x = newX;
        y = newY;
        color = newColor;
        symbol = newSymbol;
    }

    public void Draw()
    {
        Console.SetCursorPosition(CursorX, CursorY);
        Console.ForegroundColor = color;
        
        Console.Write(symbol);
    }

    public void Move(double distanceToMoveX, double distanceToMoveY, int screenWidth, int screenHeight)
    {
        x += distanceToMoveX;
        if(x < 0)
        {
            x = 0;
        }
        else if(x > screenWidth - 1)
        {
            x = screenWidth - 1;
        }
        y += distanceToMoveY;
        if(y < 0)
        {
            y = 0;
        }
        else if(y > screenHeight - 1)
        {
            y = screenHeight - 1;
        }
    }

    public virtual void Update(double dt, int screenWidth, int screenHeight)
    {
        
    }
}
