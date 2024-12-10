using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

public class LevelTwoCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    private DisableScreenCommand disableScreenCommand;
    public LevelTwoCommand(GameStateMachine gameStateMachine, Dictionary<Rectangle, ICommand> list, MouseController gameMouseController, BlackJackStateMachine blackJackStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
        disableScreenCommand = new DisableScreenCommand(list, gameMouseController, blackJackStateMachine, gameStateMachine);
    }
    public void Execute()
    {
        gameStateMachine.setLevelTwo();
        gameStateMachine.setGameStateRunning();
        disableScreenCommand.Execute();
        disableScreenCommand.Set();
        Console.WriteLine("lvl2Command");
    }
}