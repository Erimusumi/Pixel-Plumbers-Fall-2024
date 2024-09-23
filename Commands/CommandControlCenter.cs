using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using System.Globalization;
public class CommandControlCenter
{
    private ICommand SetMovingRightMarioCommand;
    private ICommand SetMovingLeftMarioCommand;
    private ICommand SetJumpingUpMarioCommand;
    private ICommand EnemySwitch;
    private ICommand blockTCommand;
    private ICommand blockYCommand;
    private KeyboardController keyboardController;
    public CommandControlCenter(Game1 game)
	{
        SetJumpingUpMarioCommand = new SetJumpUp(game);
        SetMovingRightMarioCommand = new SetMoveRightCommand(game);
        SetMovingLeftMarioCommand = new SetMoveLeftCommand(game);
        EnemySwitch = new EnemySwitch(game);
        blockTCommand = new blockTCommand(game);
        blockYCommand = new blockYCommand(game);

        keyboardController.addCommand(Keys.Right, SetMovingRightMarioCommand);
        keyboardController.addCommand(Keys.Left, SetMovingLeftMarioCommand);
        keyboardController.addCommand(Keys.Up, SetJumpingUpMarioCommand);
        keyboardController.addCommand(Keys.P, EnemySwitch);
        keyboardController.addCommand(Keys.O, EnemySwitch);
        keyboardController.addCommand(Keys.T, blockTCommand);
        keyboardController.addCommand(Keys.Y, blockYCommand);
        game.SetKey(keyboardController);
    }



}
