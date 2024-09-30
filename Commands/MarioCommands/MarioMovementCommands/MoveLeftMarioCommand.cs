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

        movingLeftBigMarioCommand = new MovingLeftBigMarioCommand(game, marioTexture);
        movingLeftSmallMarioCommand = new MoveLeftSmallMarioCommand(game, marioTexture);
        movingLeftFireMarioCommand = new MovingLeftFireMarioCommand(game, marioTexture);
    }

    public void Execute()
    {
        game.marioPosition.X -= 3;
        game.facingRight = false;


        if (!game.isJumping)
        {
            switch (game.currentMarioState)
            {
                case Game1.MarioState.Small:

                    movingLeftSmallMarioCommand.Execute();
                    break;
                case Game1.MarioState.Big:
                    movingLeftBigMarioCommand.Execute();
                    break;
                case Game1.MarioState.Fire:
                    movingLeftFireMarioCommand.Execute();
                    break;
            }
        }

    }
}
