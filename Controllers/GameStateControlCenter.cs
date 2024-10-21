using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;

public class GameStateControlCenter
{
    private GameStateMachine gameStateMachine;
    private KeyboardController gameKeyboardController;
    private MouseController gameMouseController;
    private Game1 game;
    private StartScreenText startScreenText;

    public GameStateControlCenter(GameStateMachine gameStateMachine, KeyboardController gameKeyboardController, MouseController gameMouseController, Game1 game, StartScreenText startScreenText)
    {
        this.gameKeyboardController = gameKeyboardController;
        this.gameMouseController = gameMouseController;
        this.gameStateMachine = gameStateMachine;
        this.game = game;
        this.startScreenText = startScreenText;

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        // Keyboard commands
        ICommand startGameCommand = new RunGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D9, startGameCommand);

        ICommand quitGameCommand = new QuitGameCommand(game);
        gameKeyboardController.addCommand(Keys.Q, quitGameCommand);

        ICommand resetGameCommand = new ResetGameCommand(game);
        gameKeyboardController.addCommand(Keys.R, resetGameCommand);

        ICommand pauseGameCommand = new PauseGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D3, pauseGameCommand);

        ICommand startScreenCommand = new StartScreeGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D0, startScreenCommand);

        // Mouse commands
        ICommand player1ClickCommand = new PrintMessageCommand("1 PLAYER");
        ICommand player2ClickCommand = new PrintMessageCommand("2 PLAYER");
        ICommand helpClickCommand = new PrintMessageCommand("HELP");

        gameMouseController.AddCommand(startScreenText.GetPlayer1Region(), player1ClickCommand);
        gameMouseController.AddCommand(startScreenText.GetPlayer2Region(), player2ClickCommand);
        gameMouseController.AddCommand(startScreenText.GetHelpRegion(), helpClickCommand);
    }
}
