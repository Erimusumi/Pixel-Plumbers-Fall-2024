
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class JumpingLeftFireMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public JumpingLeftFireMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
    }

    public void Execute()
    {
        game.currentMarioSprite = new JumpingLeftFireMario(marioTexture);
    }
}