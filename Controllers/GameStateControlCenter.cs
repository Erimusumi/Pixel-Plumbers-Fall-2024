using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GameStateControlCenter
{
    private GameStateMachine gameStateMachine;
    private KeyboardController gameController;
    private Game1 game;

    public GameStateControlCenter(GameStateMachine gameStateMachine, KeyboardController gameController, Game1 game)
    {
        this.gameController = gameController;
        this.gameStateMachine = gameStateMachine;
        this.game = game;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        ICommand startGameCommand = new RunGameCommand(gameStateMachine);
        gameController.addCommand(Keys.D9, startGameCommand);

        ICommand quitGameCommand = new QuitGameCommand(game);
        gameController.addCommand(Keys.Q, quitGameCommand);

        ICommand resetGameCommand = new ResetGameCommand(game);
        gameController.addCommand(Keys.R, resetGameCommand);

        ICommand pauseGameCommand = new PauseGameCommand(gameStateMachine);
        gameController.addCommand(Keys.D3, pauseGameCommand);

        ICommand startScreenCommand = new StartScreeGameCommand(gameStateMachine);
        gameController.addCommand(Keys.D0, startScreenCommand);
    }
}
