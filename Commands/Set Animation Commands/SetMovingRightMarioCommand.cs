using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetMovingRightMarioCommand : ICommand
{
    private Game1 game;
    public SetMovingRightMarioCommand(Game1 game)
    {
        this.game = game;
    }
    public void Execute()
    {
        game.CurrentMarioSprite = game.MovingRightMarioAnimation;
    }
}