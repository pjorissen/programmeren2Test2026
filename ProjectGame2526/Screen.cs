using System;

namespace ProjectGame2526;

public class Screen
{
    protected string text;

    protected ConsoleColor foregroundColor;
    protected ConsoleColor backGroundColor;

    public string Text
    {
        get {return text;}
        set {text = value;}
    }

    public ConsoleColor ForegroundColor
    {
        get{return foregroundColor;}
        set{foregroundColor = value;}
    }

    public ConsoleColor BackgroundColor
    {
        get{return BackgroundColor;}
        set{backGroundColor = value;}
    }

    public Screen(string filepath)
    {
        foregroundColor = ConsoleColor.White;
        backGroundColor = ConsoleColor.Black;

        StreamReader streamReader = null;
        try
        {
            streamReader = new StreamReader(filepath);
            
            text = streamReader.ReadToEnd();
        }
        catch (Exception e)
        {
            //Console.WriteLine("Oops somethign went wrong.");
            Console.WriteLine(e);
        }
        finally
        {
            streamReader.Close();
        }
    }

    public Screen(string filepath, ConsoleColor newForeGroundColor, ConsoleColor newBackGroundColor)
    {
        foregroundColor = newForeGroundColor;
        backGroundColor = newBackGroundColor;

        StreamReader streamReader = null;
        try
        {
            streamReader = new StreamReader(filepath);
            
            text = streamReader.ReadToEnd();
        }
        catch (Exception e)
        {
            //Console.WriteLine("Oops somethign went wrong.");
            Console.WriteLine(e);
        }
        finally
        {
            streamReader.Close();
        }
    }

    public virtual void Draw()
    {
        Console.SetCursorPosition(0,0);
        Console.ForegroundColor = foregroundColor;
        Console.BackgroundColor = backGroundColor;
        Console.WriteLine(text);
    }
}
