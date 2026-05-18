using System;
using System.Diagnostics;

namespace ProjectGame2526;

public class ExitGameMenuItem : MenuItem
{
    public ExitGameMenuItem() : base("Exit")
    {
        
    }

    public void Activate()
    {
        Environment.Exit(0);
    }
}
