using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class IdleLeftFireMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public IdleLeftFireMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
    }

    public void Execute()
    {
        game.currentMarioSprite = new IdleLeftFireMario(marioTexture);
    }
}
