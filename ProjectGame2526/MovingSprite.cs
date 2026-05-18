namespace ProjectGame2526;

public class MovingSprite: Sprite
{
    protected double xSpeed;
    protected double ySpeed;
    
    public MovingSprite(int newX, int newY, ConsoleColor newColor, char newSymbol, double newXSpeed, double newYSpeed)
    : base(newX, newY,newColor, newSymbol)
    {
        xSpeed = newXSpeed;
        ySpeed = newYSpeed;
    }


    public override void Update(double dt, int screenWidth, int screenHeight)
    {
        Move(xSpeed * dt, ySpeed*dt, screenWidth, screenHeight);
    }
}
