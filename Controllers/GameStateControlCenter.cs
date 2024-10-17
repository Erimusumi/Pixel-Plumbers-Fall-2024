using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GameStateControlCenter
{
    private GameStateMachine gameStateMachine;
    private KeyboardController gameController;

    public GameStateControlCenter(GameStateMachine gameStateMachine, KeyboardController gameController)
    {
        this.gameController = gameController;
        this.gameStateMachine = gameStateMachine;
        InitializeCommmands();
    }
    private void InitializeCommmands()
    {
        ICommand startGameCommand = new StartGameCommand(gameStateMachine);
        gameController.addCommand(Keys.D0, startGameCommand);
    }
}