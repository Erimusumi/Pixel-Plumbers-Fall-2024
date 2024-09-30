using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class CrouchLeftBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite crouchLeftBigMario;

    public CrouchLeftBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        crouchLeftBigMario = new CrouchLeftBigMario(marioTexture);
    }

    public void Execute()
    {
        game.currentMarioSprite = crouchLeftBigMario;
    }
}
