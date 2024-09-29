using System;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;


public class blockTCommand : ICommand
{
    private Game1 g;

    public blockTCommand(Game1 game)
    {
        g = game;

    }

    public void Execute()
    {
        if (g.index > 0)
        {
            g.index--;
        }
    }
}
