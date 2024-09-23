using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;

public class SetMoveLeftCommand : ICommand
{
    private Game1 game;
    private GameTime gameTime;
    public SetMoveLeftCommand(Game1 game)
    {
        this.game = game;
        this.gameTime = gameTime;
    }
    public void Execute()
    {
        game.FacingRight = false;
        game.MovingLeft = true;
        game.MarioPosition.X -= game.updatedMarioSpeed;
        if (!game.IsJumping)
        {
            game.MovingLeftMarioAnimation.Update(gameTime);
        }
    }
}
