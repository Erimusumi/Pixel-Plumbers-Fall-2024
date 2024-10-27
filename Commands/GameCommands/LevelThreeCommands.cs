using Pixel_Plumbers_Fall_2024;

public class LevelThreeCommand : ICommand
{
    private GameStateMachine gameStateMachine;
    public LevelThreeCommand(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    public void Execute()
    {
        gameStateMachine.setLevelThree();
        gameStateMachine.setGameStateRunning();
    }
}