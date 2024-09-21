using Pixel_Plumbers_Fall_2024;

public class WalkRightCommand : ICommand
{
    private ISprite sprite;
    public WalkRightCommand(ISprite sprite)
    {
        this.sprite = sprite;
    }
    public void Execute(Game1 game1)
    {
    }
}