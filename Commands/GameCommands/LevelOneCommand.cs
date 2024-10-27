using Pixel_Plumbers_Fall_2024;

public class LevelOneCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public LevelOneCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setLevelOne();
        gameStateMachine.setGameStateRunning();
    }
}