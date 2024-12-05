using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class LevelOneCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public LevelOneCommand(GameStateMachine gameStateMachine, Rectangle thisRectangle, Dictionary<Rectangle, ICommand> list, MouseController gameMouseController)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setLevelOne();
        gameStateMachine.setGameStateRunning();
    }
}