using System;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
public class blockYCommand : ICommand
{
    private Game1 g;

    public blockYCommand(Game1 game)
    {
        g = game;

    }

    public void Execute()
    {
        if (g.index < g.n - 1)
        {
            g.index++;
        }
    }
}

