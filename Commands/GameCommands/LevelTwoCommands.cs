using Pixel_Plumbers_Fall_2024;

public class LevelTwoCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public LevelTwoCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setLevelTwo();
        gameStateMachine.setGameStateRunning();
    }
}