using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework.Graphics;

public class MoveRightMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand movingRightSmallMarioCommand;
    private ICommand movingRightBigMarioCommand;
    private ICommand movingRightFireMariocommand;

    public MoveRightMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        movingRightBigMarioCommand = new MovingRightBigMarioCommand(game, marioTexture);
        movingRightSmallMarioCommand = new MoveRightSmallMarioCommand(game, marioTexture);
        movingRightFireMariocommand = new MovingRightFireMarioCommand(game, marioTexture);
    }
    public void Execute()
    {
        game.marioPosition.X += 3;
        game.facingRight = true;

        if (!game.isJumping)
        {
            switch (game.currentMarioState)
            {
                case Game1.MarioState.Small:
                    movingRightSmallMarioCommand.Execute();
                    break;
                case Game1.MarioState.Big:
                    movingRightBigMarioCommand.Execute();
                    break;
                case Game1.MarioState.Fire:
                    movingRightFireMariocommand.Execute();
                    break;
            }
        }
    }
}