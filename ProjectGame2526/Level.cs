using System;
using System.Security.Principal;

namespace ProjectGame2526;

public class Level
{
    protected LevelElement[,] level;

    public LevelElement[,] LevelField
    {
        get {return level; }
        set {level = value; }
    }

    public Level(int width, int height)
    {
        level = new LevelElement[height, width];

        for(int row = 0; row < level.GetLength(0); row++)
        {
            for(int column = 0; column < level.GetLength(1); column++)
            {
                if(row == 0 || row == height - 1 || column == 0 || column == width - 1)
                {
                    level[row, column] = new LevelElement(LevelElementType.Wall);
                }
                else
                {
                    level[row, column] = new LevelElement();
                }
            }
        }
    }

    public void Draw()
    {
        for(int row = 0; row < level.GetLength(0); row++)
        {
            for(int column = 0; column < level.GetLength(1); column++)
            {
                level[row, column].Draw(column,row);
            }
        }
    }

    public LevelElementType GetElementTypeAt(int row, int column)
    {
        return level[row, column].Type;
    }
}
