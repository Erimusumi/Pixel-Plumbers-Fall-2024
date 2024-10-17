using System.Runtime.CompilerServices;

public class StartGameCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public StartGameCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setGameStateRunning();
    }
}