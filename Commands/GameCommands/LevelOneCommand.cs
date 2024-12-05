using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LevelOneCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    private DisableScreenCommand disableScreenCommand;
    public LevelOneCommand(GameStateMachine gameStateMachine, Dictionary<Rectangle, ICommand> list, MouseController gameMouseController, BlackJackStateMachine blackJackStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
        disableScreenCommand = new DisableScreenCommand(list, gameMouseController, blackJackStateMachine, gameStateMachine);

    }
    public void Execute()
    {
        gameStateMachine.setLevelOne();
        gameStateMachine.setGameStateRunning();

        disableScreenCommand.Execute();
        disableScreenCommand.Set();
    }
}