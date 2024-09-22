using Pixel_Plumbers_Fall_2024;

public class IdleLeftCommand : ICommand
{
    private Game1 game1;
    public IdleLeftCommand(Game1 game1)
    {
        this.game1 = game1;
    }
    public void Execute(Game1 game1)
    {
        game1.CurrentMarioSprite = game1.idleLeftMario;
    }
}