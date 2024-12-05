using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

public class GameStateControlCenter
{
    private GameStateMachine gameStateMachine;
    private KeyboardController gameKeyboardController;
    private MouseController gameMouseController;
    private Game1 game;
    private StartScreenSprite startScreenSprite;
    private LevelScreenSprite levelScreenSprite;
    private MusicMachine MusicMachine;
    private BlackJackStateMachine blackJackStateMachine;

    public GameStateControlCenter(GameStateMachine gameStateMachine, KeyboardController gameKeyboardController, MouseController gameMouseController, Game1 game, StartScreenSprite startScreenSprite, LevelScreenSprite levelScreenSprite, SoundManager musics, BlackJackStateMachine blackJackStateMachine)
    {
        this.gameKeyboardController = gameKeyboardController;
        this.gameMouseController = gameMouseController;
        this.gameStateMachine = gameStateMachine;
        this.game = game;
        this.startScreenSprite = startScreenSprite;
        this.levelScreenSprite = levelScreenSprite;
        this.blackJackStateMachine = blackJackStateMachine;
        MusicMachine = new MusicMachine(musics);
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        // Keyboard commands
        ICommand startGameCommand = new RunGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D9, startGameCommand);

        ICommand musicCommand = new MusicCommand(MusicMachine);
        gameKeyboardController.addCommand(Keys.M, musicCommand);

        ICommand quitGameCommand = new QuitGameCommand(game);
        gameKeyboardController.addCommand(Keys.Q, quitGameCommand);

        ICommand resetGameCommand = new ResetGameCommand(game);
        gameKeyboardController.addCommand(Keys.R, resetGameCommand);

        ICommand pauseGameCommand = new PauseGameCommand(gameStateMachine, MusicMachine);
        gameKeyboardController.addCommand(Keys.D3, pauseGameCommand);

        ICommand startScreenCommand = new StartScreeGameCommand(gameStateMachine);
        gameKeyboardController.addCommand(Keys.D0, startScreenCommand);

        // Mouse commands
        ICommand helpClickCommand = new PrintMessageCommand("HELP");
        gameMouseController.AddCommand(startScreenSprite.GetHelpRectangle(), helpClickCommand);

        ICommand singlePlayerCommand = new SingleplayerCommand(gameStateMachine);
        gameMouseController.AddCommand(startScreenSprite.GetOnePlayerRectangle(), singlePlayerCommand); // Single Player
        ICommand multiplayerCommand = new MultiplayerCommand(gameStateMachine);
        gameMouseController.AddCommand(startScreenSprite.GetTwoPlayerRectangle(), multiplayerCommand); // Multiplayer

        ICommand levelOneCommand = new LevelOneCommand(gameStateMachine);
        gameMouseController.AddCommand(levelScreenSprite.GetLevelOneRectangle(), levelOneCommand);

        ICommand levelTwoCommand = new LevelTwoCommand(gameStateMachine);
        gameMouseController.AddCommand(levelScreenSprite.GetLevelTwoRectangle(), levelTwoCommand);

        ICommand levelThreeCommand = new LevelThreeCommand(gameStateMachine);
        gameMouseController.AddCommand(levelScreenSprite.GetLevelThreeRectangle(), levelThreeCommand);

        ICommand BlackJackCommand = new BlackJackCommand(blackJackStateMachine, gameStateMachine);
        gameMouseController.AddCommand(blackJackStateMachine.DestinationRectangle(), BlackJackCommand);

        ICommand CardCommand = new CardCommand(blackJackStateMachine);
        gameMouseController.AddCommand(new Rectangle(660, 130, 75, 110), CardCommand);

        ICommand StandCommand = new StandCommand(blackJackStateMachine);
        gameMouseController.AddCommand(new Rectangle(660, 270, 100, 50), StandCommand);
    }
}
