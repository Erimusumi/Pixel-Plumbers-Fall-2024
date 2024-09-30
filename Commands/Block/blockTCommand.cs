using System;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;


public class blockTCommand : ICommand
{
    private Game1 g;
    private Boolean b;

    public blockTCommand(Game1 game)
    {
        g = game;
    }

    public void Execute()
    {
        if (g.index2 > 0)
        {
            g.index2--;
        }
        else if (g.index1 > 0)
        {
            g.index1--;
        }
    }
}
