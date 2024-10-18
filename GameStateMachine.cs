using System.ComponentModel;

public class GameStateMachine
{
    public enum GameStates { Start, Running, Paused, Over }
    public GameStates currentGameState = GameStates.Start;

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
}

