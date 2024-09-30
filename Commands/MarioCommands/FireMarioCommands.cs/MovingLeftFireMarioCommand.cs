using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class MovingLeftFireMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    public MovingLeftFireMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;
    }

    public void Execute()
    {
        if (game.Mario.GetDirection() == MarioState.MarioDirectionEnum.Right)
        {
            game.Mario.SwapDir();
        }
        game.Mario.Run();
    }
}
