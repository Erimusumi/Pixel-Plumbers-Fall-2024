using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class SetMarioFireCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public SetMarioFireCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentMarioState = Game1.MarioState.Fire;
    }
}
