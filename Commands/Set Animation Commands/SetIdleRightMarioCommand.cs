using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetIdleRightMarioCommand : ICommand
{
    private Game1 game;
    public SetIdleRightMarioCommand(Game1 game)
    {
        this.game = game;
    }
    public void Execute()
    {
        game.CurrentMarioSprite = game.IdleRightMario;
    }
}