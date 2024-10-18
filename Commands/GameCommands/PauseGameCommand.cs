public class PauseGameCommand : ICommand
{
    private GameStateMachine gameStateMachine;

    public PauseGameCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }

    public void Execute()
    {
        if (gameStateMachine.isCurrentStatePaused())
        {
            gameStateMachine.setGameStateRunning();
        }
        else
        {
            gameStateMachine.setGameStatePaused();
        }
    }
}
