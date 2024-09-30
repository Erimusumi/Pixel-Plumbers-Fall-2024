using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class IdleLeftBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite idleLeftBigMario;

    public IdleLeftBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        idleLeftBigMario = new IdleLeftBigMario(marioTexture);
    }

    public void Execute()
    {        game.currentMarioSprite = idleLeftBigMario;
    }
}
