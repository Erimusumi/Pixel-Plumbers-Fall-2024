using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetMoveLeftCommand : ICommand
{
    private Game1 game;
    public SetMoveLeftCommand(Game1 game)
    {
        this.game = game;
    }
    public void Execute()
    {
        game.FacingRight = false;
        game.MovingRight = false;
        game.MovingLeft = true;
        game.MarioPosition.X -= game.updatedMarioSpeed;

        if (!game.IsJumping)
        {
            game.CurrentMarioSprite = game.MovingLeftMarioAnimation;
        }
    }
}
