using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class resetCommand : ICommand
{
    Game1 game;
    public resetCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {

    }
}
