using System.Runtime.CompilerServices;

public class RunGameCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public RunGameCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setGameStateRunning();
    }
}