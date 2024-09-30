using MarioGame;
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
    {
        game.marioPosition.X -= 5;
        game.currentMarioSprite = idleLeftBigMario;
    }
}
