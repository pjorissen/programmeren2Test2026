using System.Xml.Linq;

namespace ProjectGame2526;

public class Enemy: MovingSprite
{
    protected Level gameLevel;
    public Enemy(int startPosX, int startPosY, Level newLevel): base(startPosX,startPosY,ConsoleColor.Yellow,'E',20,0)
    {
        gameLevel = newLevel;
    }

    public override void Update(double dt, int screenWidth, int screenHeight)
    {
        double currentPositionX = x;
        double currentPositionY = y;
        base.Update(dt, screenWidth, screenHeight);

        //after move check..
        if(gameLevel.GetElementTypeAt(CursorY,CursorX) == LevelElementType.Wall)   
        {
            //reset position to before update
            x = currentPositionX;
            y = currentPositionY;
            //turn xspeed around
            xSpeed = -xSpeed;
        }
    }
}
