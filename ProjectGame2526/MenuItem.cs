using System;

namespace ProjectGame2526;

public class MenuItem
{
    protected string text;

    public string Text
    {
        get{return text;}
    }

    public MenuItem(string newText)
    {
        text = newText;
    }

    public virtual void Activate()
    {
        
    }

    public void Draw()
    {
        Console.WriteLine("\n\t{0}\n", text);
    }
}
