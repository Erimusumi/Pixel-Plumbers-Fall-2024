using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class IdleRightFireMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public IdleRightFireMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
    }

    public void Execute()
    {
        game.currentMarioSprite = new IdleRightFireMario(marioTexture);
    }
}
