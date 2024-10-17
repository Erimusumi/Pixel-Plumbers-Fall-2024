using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class resetCommand : ICommand
{
    Game1 g;
    public resetCommand(Game1 game)
    {
        g = game;
    }

    public void Execute()
    {
        // Reset item management
        g.currentItem = 0;

        // Reset enemies (if applicable)
        g.spriteEnemy = new Goomba(480, 400); // or whichever enemy you are using
        g.controlG = new GoombaCommand(new Goomba(480, 400)); // Reset enemy control

        // Reset blocks and obstacles
        g.index1 = 0;
        g.index2 = 0;

        // Reset item manager
        g.manager = new ItemManager();
        g.numItems = 3;

    }
}
