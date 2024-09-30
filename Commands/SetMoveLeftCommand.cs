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
        if (game.MovingRight == true)
        {
            game.Mario.SwapDir();
        }

        if (game.marioVelocity.X > -5f)
        {
            game.marioVelocity.X -= .5f;
        }
        if (game.marioVelocity.X < -5f)
        {
            game.marioVelocity.X = -5f;
        }

        game.FacingRight = false;
        game.MovingRight = false;
        game.MovingLeft = true;
        game.MarioPosition.X += game.MarioVelocity.X;

        if (game.MarioVelocity.Y == 0)
        {
            game.Mario.Run();
        }
    }
}
