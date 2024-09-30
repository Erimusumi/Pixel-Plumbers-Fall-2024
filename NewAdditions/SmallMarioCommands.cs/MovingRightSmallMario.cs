using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class MoveRightSmallMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public MoveRightSmallMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
    }

    public void Execute()
    {
        game.currentMarioSprite = new MovingRightSmallMario(marioTexture);
    }
}