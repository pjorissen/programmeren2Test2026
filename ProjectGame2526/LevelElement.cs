using System;
using System.Runtime.CompilerServices;

namespace ProjectGame2526;

public enum LevelElementType{
    Open,
    Wall
}

public class LevelElement
{
    protected LevelElementType type;

    public LevelElementType Type
    {
        get{ return type;}
        set{ type = value;}
    }

    public LevelElement()
    {
        type = LevelElementType.Open;
    }

    public LevelElement(LevelElementType newType)
    {
        type = newType;
    }

    public void Draw(int x, int y)
    {
        ConsoleColor origBackColor = Console.BackgroundColor;
        Console.SetCursorPosition(x, y);
        switch(type)
        {
            case LevelElementType.Open:
                Console.BackgroundColor = ConsoleColor.Black;
                break;
            case LevelElementType.Wall:
                Console.BackgroundColor = ConsoleColor.White;
                break;
        }
        Console.Write(" ");
        Console.BackgroundColor = origBackColor;
    }
}
