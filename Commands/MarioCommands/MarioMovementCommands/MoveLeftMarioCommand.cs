using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class MoveLeftMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand movingLeftSmallMarioCommand;
    private ICommand movingLeftBigMarioCommand;
    private ICommand movingLeftFireMarioCommand;

    public MoveLeftMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        //movingLeftBigMarioCommand = new MovingLeftBigMarioCommand(game, marioTexture);
        //movingLeftSmallMarioCommand = new MoveLeftSmallMarioCommand(game, marioTexture);
        //movingLeftFireMarioCommand = new MovingLeftFireMarioCommand(game, marioTexture);
    }

    public void Execute()
    {
        if (game.marioVelocity.X > -5f)
        {
            game.marioVelocity.X -= .2f;
            if (game.marioVelocity.X < -5f)
            {
                game.marioVelocity.X = -5f;
            }
        }
        
        game.marioPosition.X += game.marioVelocity.X;
        game.facingRight = false;

        if (game.Mario.GetDirection() == MarioState.MarioDirectionEnum.Right)
        {
            game.Mario.SwapDir();
        }
        game.Mario.Run();

    }
}
