using MarioGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CrouchRightBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite crouchRightBigMario;

    public CrouchRightBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        crouchRightBigMario = new CrouchRightBigMario(marioTexture);
    }

    public void Execute()
    {
        game.currentMarioSprite = crouchRightBigMario;
    }
}
