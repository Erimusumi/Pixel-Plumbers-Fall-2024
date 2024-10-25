using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

public class GameStateControlCenter
{
    private GameStateMachine gameStateMachine;
    private KeyboardController gameKeyboardController;
    private MouseController gameMouseController;
    private Game1 game;
    private StartScreenSprite startScreenSprite;
    private MusicStateMachine MusicStateMachine;

    public GameStateControlCenter(GameStateMachine gameStateMachine, KeyboardController gameKeyboardController, MouseController gameMouseController, Game1 game, StartScreenSprite startScreenSprite, ContentManager content)
    {
        this.gameKeyboardController = gameKeyboardController;
        this.gameMouseController = gameMouseController;
        this.gameStateMachine = gameStateMachine;
        this.game = game;
        this.startScreenSprite = startScreenSprite;
        MusicStateMachine = new MusicStateMachine(content);

        InitializeCommands();
    }

    private void InitializeCommands()
    {
        // Keyboard commands
        ICommand startGameCommand = new RunGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D9, startGameCommand);

        ICommand musicCommand = new MusicCommand(MusicStateMachine);
        gameKeyboardController.addCommand(Keys.M, musicCommand);

        ICommand quitGameCommand = new QuitGameCommand(game);
        gameKeyboardController.addCommand(Keys.Q, quitGameCommand);

        ICommand resetGameCommand = new ResetGameCommand(game);
        gameKeyboardController.addCommand(Keys.R, resetGameCommand);

        ICommand pauseGameCommand = new PauseGameCommand(gameStateMachine, MusicStateMachine);
        gameKeyboardController.addCommand(Keys.D3, pauseGameCommand);

        ICommand startScreenCommand = new StartScreeGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D0, startScreenCommand);

        // Mouse commands
        ICommand player1ClickCommand = new PrintMessageCommand("1 PLAYER");
        ICommand player2ClickCommand = new PrintMessageCommand("2 PLAYER");
        ICommand helpClickCommand = new PrintMessageCommand("HELP");

        gameMouseController.AddCommand(startScreenSprite.GetPlayer1Region(), startGameCommand);
        gameMouseController.AddCommand(startScreenSprite.GetPlayer2Region(), startGameCommand);
        gameMouseController.AddCommand(startScreenSprite.GetHelpRegion(), helpClickCommand);
    }
}
