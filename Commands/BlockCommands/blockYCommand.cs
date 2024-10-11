using System;
using System.Runtime.InteropServices;
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

        if (g.index1 < g.n1 - 1)
        {
            g.index1++;
        }
        else if (g.index2 < g.n2 - 1)
        {
            g.index2++;
        }
    }
}

