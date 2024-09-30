using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingRightBigMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;
    private IMarioSprite movingRightBigMario;

    public MovingRightBigMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
        movingRightBigMario = new MovingRightBigMario(marioTexture);
    }

    public void Execute()
    {
        if (game.Mario.GetDirection() == MarioState.MarioDirectionEnum.Left)
        {
            game.Mario.SwapDir();
        }
        game.Mario.Run();
    }
}
