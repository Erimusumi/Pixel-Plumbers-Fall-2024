using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetMovingLeftMarioCommand : ICommand
{
    private Game1 game;
    public SetMovingLeftMarioCommand(Game1 game)
    {
        this.game = game;
    }
    public void Execute()
    {
        game.CurrentMarioSprite = game.MovingLeftMarioAnimation;
    }
}