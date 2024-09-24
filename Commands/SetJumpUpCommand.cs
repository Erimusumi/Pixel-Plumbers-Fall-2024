using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetJumpUp : ICommand
{
    private Game1 game;

    public SetJumpUp(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        if (!game.IsJumping)
        {
            game.MarioVelocity.Y = game.JumpSpeed;
            game.IsJumping = true;

            if (game.FacingRight)
            {
                game.CurrentMarioSprite = game.JumpingRightMario;
            }
            else
            {
                game.CurrentMarioSprite = game.JumpingLeftMario;
            }
        }
    }
}
