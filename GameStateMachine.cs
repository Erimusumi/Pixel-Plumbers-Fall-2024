using System.ComponentModel;
using System.Diagnostics.Contracts;

public class GameStateMachine
{
    public enum GameStates { Start, Levels, Running, Paused, Over }
    public enum LevelStates { LevelZero, LevelOne, LevelTwo, LevelThree }

    public GameStates currentGameState = GameStates.Start;
    public LevelStates currentLevelState = LevelStates.LevelZero;

    public void setGameStateStart()
    {
        currentGameState = GameStates.Start;
    }

    public void setGameStateRunning()
    {
        currentGameState = GameStates.Running;
    }

    public void setGameStatePaused()
    {
        currentGameState = GameStates.Paused;
    }

    public void setGameStateOver()
    {
        currentGameState = GameStates.Over;
    }

    public bool isCurrentStateStart()
    {
        return currentGameState == GameStates.Start;
    }

    public bool isCurrentStateRunning()
    {
        return currentGameState == GameStates.Running;
    }

    public bool isCurrentStatePaused()
    {
        return currentGameState == GameStates.Paused;
    }

    public bool isCurrentStatOver()
    {
        return currentGameState == GameStates.Start;
    }

    public void setGameLevelsScreen()
    {
        currentGameState = GameStates.Levels;
    }

    public void setLevelOne()
    {
        currentLevelState = LevelStates.LevelOne;
    }

    public void setLevelTwo()
    {
        currentLevelState = LevelStates.LevelTwo;
    }

    public void setLevelThree()
    {
        currentLevelState = LevelStates.LevelThree;
    }

    public bool isLevelZero()
    {
        return currentLevelState == LevelStates.LevelZero;
    }

    public bool isLevelOne()
    {
        return currentLevelState == LevelStates.LevelOne;
    }

    public bool isLevelTwo()
    {
        return currentLevelState == LevelStates.LevelTwo;
    }

    public bool isLevelThree()
    {
        return currentLevelState == LevelStates.LevelThree;
    }
}

