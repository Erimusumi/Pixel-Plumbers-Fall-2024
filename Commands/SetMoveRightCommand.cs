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
        game.FacingRight = true;
        game.MovingRight = true;
        game.MovingLeft = false;
        game.MarioPosition.X += game.updatedMarioSpeed;
        
        if (!game.IsJumping)
        {
            game.CurrentMarioSprite = game.MovingRightMarioAnimation;
        }
    }
}
