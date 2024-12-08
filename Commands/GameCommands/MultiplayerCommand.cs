using System.Runtime.CompilerServices;

public class MultiplayerCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    private ICommand levelScreenCommand;

    public MultiplayerCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
        levelScreenCommand = new LevelScreenCommand(gameStateMachine);
    }
    public void Execute()
    {
        gameStateMachine.setGameMultiplayer();
        levelScreenCommand.Execute();
    }
}