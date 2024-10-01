using System;
using Pixel_Plumbers_Fall_2024;

public class quitCommand : ICommand
{
	Game1 g;
	public quitCommand(Game1 game)
	{
		g = game;
	}
	public void Execute()
	{
		g.Exit();
	}
}
