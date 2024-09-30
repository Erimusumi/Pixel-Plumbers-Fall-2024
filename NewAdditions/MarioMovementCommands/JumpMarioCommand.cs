using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class JumpMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand jumpRightSmallMarioCommand;
    private ICommand jumpLeftSmallMarioCommand;
    private ICommand jumpRightBigMarioCommand;
    private ICommand jumpLeftBigMarioCommand;
    private ICommand jumpRightFireMarioCommand;  // Fixed the command initialization
    private ICommand jumpLeftFireMarioCommand;   // Fixed the command initialization

    public JumpMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        // Initialize the specific jump commands for different Mario states
        jumpRightSmallMarioCommand = new JumpRightSmallMarioCommand(game, marioTexture);
        jumpLeftSmallMarioCommand = new JumpLeftSmallMarioCommand(game, marioTexture);
        jumpRightBigMarioCommand = new JumpingRightBigMarioCommand(game, marioTexture);
        jumpLeftBigMarioCommand = new JumpingLeftBigMarioCommand(game, marioTexture);
        jumpRightFireMarioCommand = new JumpingRightFireMarioCommand(game, marioTexture);  // Correct assignment
        jumpLeftFireMarioCommand = new JumpingLeftFireMarioCommand(game, marioTexture);    // Correct assignment
    }

    public void Execute()
    {
        if (!game.isJumping)
        {
            // Set Mario into jumping mode and set the upward velocity (jump speed)
            game.isJumping = true;
            game.marioVelocity.Y = game.jumpSpeed;

            switch (game.currentMarioState)
            {
                case Game1.MarioState.Small:
                    if (game.facingRight)
                    {
                        jumpRightSmallMarioCommand.Execute();
                    }
                    else
                    {
                        jumpLeftSmallMarioCommand.Execute();
                    }
                    break;
                case Game1.MarioState.Big:
                    if (game.facingRight)
                    {
                        jumpRightBigMarioCommand.Execute();
                    }
                    else
                    {
                        jumpLeftBigMarioCommand.Execute();
                    }
                    break;
                case Game1.MarioState.Fire:
                    if (game.facingRight)
                    {
                        jumpRightFireMarioCommand.Execute();
                    }
                    else
                    {
                        jumpLeftFireMarioCommand.Execute();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
