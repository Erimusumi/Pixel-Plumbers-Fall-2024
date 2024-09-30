using Pixel_Plumbers_Fall_2024;

public class SetMoveRightCommand : ICommand
{
    private Game1 game;
    public SetMoveRightCommand(Game1 game)
    {
        this.game = game;
    }
    public void Execute()
    {
        if (game.MovingLeft == true)
        {
            game.Mario.SwapDir();
        }

        if (game.MarioVelocity.X < 5f)
        {
            game.MarioVelocity.X += .5f;
        }
        if (game.MarioVelocity.X > 5f)
        {
            game.MarioVelocity.X = 5f;
        }

        game.FacingRight = true;
        game.MovingRight = true;
        game.MovingLeft = false;
        game.MarioPosition.X += game.MarioVelocity.X;
        
        if (game.MarioVelocity.Y == 0)
        {
            game.Mario.Run();
        }
    }
}
