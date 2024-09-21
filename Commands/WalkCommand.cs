using Pixel_Plumbers_Fall_2024;

public class WalkCommand : ICommand
{
    private ISprite sprite;
    public WalkCommand(ISprite sprite)
    {
        this.sprite = sprite;
    }
    public void Execute(Game1 game1)
    {
    }
}