using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LevelTwoCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public LevelTwoCommand(GameStateMachine gameStateMachine, Rectangle thisRectangle, Dictionary<Rectangle, ICommand> list, MouseController gameMouseController)
    {
        this.gameStateMachine = gameStateMachine;

    }
    public void Execute()
    {
        gameStateMachine.setLevelTwo();
        gameStateMachine.setGameStateRunning();
    }
}