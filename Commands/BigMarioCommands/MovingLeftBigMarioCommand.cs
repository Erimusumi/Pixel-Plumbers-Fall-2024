using MarioGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingLeftBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite movingLeftBigMario;

    public MovingLeftBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        movingLeftBigMario = new MovingLeftBigMario(marioTexture);
    }

    public void Execute()
    {
        game.currentMarioSprite = movingLeftBigMario;
    }
}
