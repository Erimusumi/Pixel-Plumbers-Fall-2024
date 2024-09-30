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
            game.marioVelocity.Y = game.JumpSpeed;
            game.IsJumping = true;

            game.Mario.Jump();
        }
    }
}
