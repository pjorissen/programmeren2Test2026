using System;

namespace ProjectGame2526;

public class Menu : Screen
{
    protected List<MenuItem> menuItems;

    public Menu(string filepath) : base(filepath)
    {
        menuItems = new List<MenuItem>();
    }

    public Menu(string filepath, ConsoleColor foregroundColor, ConsoleColor backgroundColor) 
    : base(filepath, foregroundColor, backgroundColor)
    {
        menuItems = new List<MenuItem>();
    }

    public void AddMenuItem(MenuItem newMenuItem)
    {
        menuItems.Add(newMenuItem);
    }

    public override void Draw()
    {
        base.Draw();

        for(int i = 0; i < menuItems.Count; i++)
        {
            menuItems[i].Draw();
        }
    }
}
