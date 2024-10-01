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
        // Reset Mario's position and velocity
        g.marioPosition = new Vector2(g.initial_mario_position.X, g.initial_mario_position.Y);
        g.marioVelocity = Vector2.Zero;
        g.facingRight = true;
        g.isJumping = false;

        // Reset speed and other variables
        g.marioSpeed = 10;
        g.updatedMarioSpeed = 0;

        // Reset item management
        g.currentItem = 0;

        // Reset enemies (if applicable)
        g.spriteEnemy = new Goomba(); // or whichever enemy you are using
        g.controlG = new GoombaCommand(new Goomba()); // Reset enemy control

        // Reset blocks and obstacles
        g.index1 = 0;
        g.index2 = 0;

        // Reset item manager
        g.manager = new ItemManager();
        g.numItems = 3;

    }
}
