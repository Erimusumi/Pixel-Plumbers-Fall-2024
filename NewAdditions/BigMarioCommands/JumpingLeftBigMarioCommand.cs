using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class JumpingLeftBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite jumpingLeftBigMario;

    public JumpingLeftBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        jumpingLeftBigMario = new JumpingLeftBigMario(marioTexture);
    }

    public void Execute()
    {
        game.currentMarioSprite = jumpingLeftBigMario;
    }
}
