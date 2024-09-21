using Pixel_Plumbers_Fall_2024;

public class WalkLeftCommand : ICommand
{
    private ISprite sprite;
    public WalkLeftCommand(ISprite sprite)
    {
        this.sprite = sprite;
    }
    public void Execute(Game1 game1)
    {
    }
}