using System;
using Pixel_Plumbers_Fall_2024;

public class QuitGameCommand : ICommand
{
	Game1 game;
	public QuitGameCommand(Game1 game)
	{
		this.game = game;
	}
	public void Execute()
	{
		game.Exit();
	}
}
