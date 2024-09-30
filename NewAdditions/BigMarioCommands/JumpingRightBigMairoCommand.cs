using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class JumpingRightBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite jumpingRightBigMario;

    public JumpingRightBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        jumpingRightBigMario = new JumpingRightBigMario(marioTexture);
    }

    public void Execute()
    {
        game.currentMarioSprite = jumpingRightBigMario;
    }
}
