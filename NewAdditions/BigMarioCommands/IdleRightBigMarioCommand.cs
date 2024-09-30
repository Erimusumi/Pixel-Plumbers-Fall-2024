using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite idleRightBigMario;

    public IdleRightBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        idleRightBigMario = new IdleRightBigtMario(marioTexture);
    }

    public void Execute()
    {
        game.MarioPosition.X += 5;
        game.currentMarioSprite = idleRightBigMario;
    }
}
