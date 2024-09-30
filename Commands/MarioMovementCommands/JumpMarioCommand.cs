using MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class JumpMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    ICommand jumpingRightBigMarioCommand;
    ICommand jumpingLeftBigMarioCommand;
    ICommand jumpingRightFireMarioCommand;
    ICommand jumpingLeftFireMarioCommand;
    ICommand jumpingRightSmallMarioCommand;
    ICommand jumpingLeftSmallMarioCommand;

    public JumpMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        jumpingRightBigMarioCommand = new JumpingRightBigMarioCommand(game, marioTexture);
        jumpingLeftBigMarioCommand = new JumpingLeftBigMarioCommand(game, marioTexture);
        jumpingRightFireMarioCommand = new JumpingRightFireMarioCommand(game, marioTexture);
        jumpingLeftFireMarioCommand = new JumpingLeftFireMarioCommand(game, marioTexture);
        jumpingRightSmallMarioCommand = new JumpRightSmallMarioCommand(game, marioTexture);
        jumpingLeftSmallMarioCommand = new JumpLeftSmallMarioCommand(game, marioTexture);
    }

    public void Execute()
    {
        if (!game.isJumping)
        {ausing MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class JumpMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand[] jumpingCommands;

    public JumpMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        // Initialize jumping commands array
        jumpingCommands = new ICommand[]
        {
            new JumpRightSmallMarioCommand(game, marioTexture),
            new JumpLeftSmallMarioCommand(game, marioTexture),
            new JumpingRightBigMarioCommand(game, marioTexture),
            new JumpingLeftBigMarioCommand(game, marioTexture),
            new JumpingRightFireMarioCommand(game, marioTexture),
            new JumpingLeftFireMarioCommand(game, marioTexture)
        };
    }

    public void Execute()
    {
        if (!game.isJumping)
        {
            game.isJumping = true;
            int commandIndex = GetJumpingCommandIndex();
            jumpingCommands[commandIndex].Execute();
        }
    }

    private int GetJumpingCommandIndex()
    {
        switch (game.currentMarioState)
        {
            case Game1.MarioState.Small:
                return game.facingRight ? 0 : 1; // Small Right / Small Left
            case Game1.MarioState.Big:
                return game.facingRight ? 2 : 3; // Big Right / Big Left
            case Game1.MarioState.Fire:
                return game.facingRight ? 4 : 5; // Fire Right / Fire Left
            default:
                return -1; // Invalid state
        }
    }
}
ausing MarioGame;
using Microsoft.Xna.Framework.Graphics;

public class JumpMarioCommand : ICommand
{
    private Game1 game;
    private Texture2D marioTexture;

    private ICommand[] jumpingCommands;

    public JumpMarioCommand(Game1 game, Texture2D marioTexture)
    {
        this.game = game;
        this.marioTexture = marioTexture;

        // Initialize jumping commands array
        jumpingCommands = new ICommand[]
        {
            new JumpRightSmallMarioCommand(game, marioTexture),
            new JumpLeftSmallMarioCommand(game, marioTexture),
            new JumpingRightBigMarioCommand(game, marioTexture),
            new JumpingLeftBigMarioCommand(game, marioTexture),
            new JumpingRightFireMarioCommand(game, marioTexture),
            new JumpingLeftFireMarioCommand(game, marioTexture)
        };
    }

    public void Execute()
    {
        if (!game.isJumping)
        {
            game.isJumping = true;
            int commandIndex = GetJumpingCommandIndex();
            jumpingCommands[commandIndex].Execute();
        }
    }

    private int GetJumpingCommandIndex()
    {
        switch (game.currentMarioState)
        {
            case Game1.MarioState.Small:
                return game.facingRight ? 0 : 1; // Small Right / Small Left
            case Game1.MarioState.Big:
                return game.facingRight ? 2 : 3; // Big Right / Big Left
            case Game1.MarioState.Fire:
                return game.facingRight ? 4 : 5; // Fire Right / Fire Left
            default:
                return -1; // Invalid state
        }
    }
}

            game.isJumping = true;
            switch (game.currentMarioState)
            {
                case Game1.MarioState.Small:
                    if (game.facingRight)
                    {
                        jumpingRightSmallMarioCommand.Execute();
                    }
                    else
                    {
                        jumpingLeftSmallMarioCommand.Execute();
                    }
                    break;
                case Game1.MarioState.Big:
                    if (game.facingRight)
                    {
                        jumpingRightBigMarioCommand.Execute();
                    }
                    else
                    {
                        jumpingLeftBigMarioCommand.Execute();
                    }
                    break;
                case Game1.MarioState.Fire:
                    if (game.facingRight)
                    {
                        jumpingRightFireMarioCommand.Execute();
                    }
                    else
                    {
                        jumpingLeftFireMarioCommand.Execute();
                    }
                    break;
            }
        }
    }
}
