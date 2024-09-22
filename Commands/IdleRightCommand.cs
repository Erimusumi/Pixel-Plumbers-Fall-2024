using Pixel_Plumbers_Fall_2024;

public class IdleRightCommand : ICommand
{
    private Game1 game1;
    public IdleRightCommand(Game1 game1)
    {
        this.game1 = game1;
    }
    public void Execute(Game1 game1)
    {
        game1.CurrentMarioSprite = game1.idleRightMario;
    }
}