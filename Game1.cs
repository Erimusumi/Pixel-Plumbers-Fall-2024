using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Audio;
using System.Net.NetworkInformation;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private GameTime gameTime;
    private float gameOverTickTimer;


    private TextureManager textureManager;

    public HudManager hudManager;

    private KeyboardController keyboardController;
    private KeyboardControllerMovement keyboardControllerMovement;
    private CommandControlCenter controlCenter;

    private Mario mario;
    private PlayerMovementController marioMovementController;
    private PlayerCommandControlCenter playerCommandControlCenter;

    private GameStateMachine gameStateMachine;
    private GameStateControlCenter gameStateControlCenter;
    private KeyboardController gameStateKeyboardController;
    private MouseController gameStateMouseController;




    //Dance
    private ISpriteAnimation Dance;



    //Fireballs
    public List<Fireball> fireballs = new List<Fireball>();

    public List<IEntity> entities = new List<IEntity>();
    private List<IEntity> entitiesRemoved = new List<IEntity>();
    private Sort sort = new Sort();
    private Sweep sweep;

    //Sound Effects
    SoundEffect oneUpSound;
    SoundEffect breakBlockSound;
    SoundEffect coinSound;
    SoundEffect fireBallSound;
    SoundEffect flagPoleSound;
    SoundEffect pipeSound;
    SoundEffect powerUpSound;
    SoundEffect powerDownSound;
    SoundEffect powerUpSpawnsSound;
    SoundEffect marioJump;
    SoundEffect marioDeath;
    SoundEffect gameOverSound;
    List<SoundEffect> marioSounds = new List<SoundEffect>();
    List<SoundEffect> ItemSounds = new List<SoundEffect>();

    // reset instances
    public Vector2 initial_mario_position;

    // Start Screen
    Rectangle screen = new Rectangle(0, 0, 800, 480);
    private SpriteFont startScreenFonts;
    private SpriteFont levelScreenFonts;

    // map layers
    //Ground Detection
    Ground ground;
    ToggleFalling toggleFalling;
    List<Rectangle> collidableRectangles;
    ToggleFalling ToggleFalling;

    //Black Jack

    private BlackJackStateMachine blackJackStateMachine;
    private SoundEffect fwip;

    // camera
    private FollowCamera camera;

    private StartScreenSprite startScreenSprite;
    private LevelScreenSprite levelScreenSprite;

    private LevelOne levelOne;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        camera = new(Vector2.Zero);
    }

    public void ResetGame()
    {
        entities.Clear();
        // entities.Add(mario);
        if (gameStateMachine.isLevelOne())
        {
            levelOne.InitializeLevel();

        }
        else if (gameStateMachine.isLevelTwo())
        {


        }

        fireballs.Clear();
        mario.Reset();

        hudManager.SetTime(400);

        camera = new(Vector2.Zero);
    }

    public void GameOver()
    {
        gameStateMachine.setGameStateOver();
        gameOverSound.Play();
    }
    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();
        this.sweep = new Sweep(gameTime);

        textureManager = new TextureManager(Content);

        Dance = new DancePole();


        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();
        controlCenter = new CommandControlCenter(this);


        levelOne = new LevelOne(this, mario, entities, entitiesRemoved, spriteBatch, gameTime, Content, textureManager);
        levelOne.InitializeLevel();

        //Ground Detection initialization
        collidableRectangles = new List<Rectangle>();
        collidableRectangles = levelOne.GetLevelOneRectangles();

        ground = new Ground(collidableRectangles);
        toggleFalling = new ToggleFalling(ground, entities);
    }

    public void SetKey(KeyboardController keys)
    {
        keyboardController = keys;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        fwip = Content.Load<SoundEffect>("Audio/flip");

        pipeSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_pipe");
        oneUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_1-up");
        coinSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_coin");
        fireBallSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_fireball");
        flagPoleSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_flagpole");
        powerUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup");
        powerUpSpawnsSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup_appears");
        marioJump = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_jump-small");
        marioDeath = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_mariodie");

        textureManager = new TextureManager(Content);

        //Sound EFX
        ItemSounds.Add(coinSound);
        ItemSounds.Add(powerUpSpawnsSound);

        gameOverSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_gameover");

        marioSounds.Add(powerUpSound);
        marioSounds.Add(pipeSound);
        marioSounds.Add(fireBallSound);
        marioSounds.Add(marioJump);
        marioSounds.Add(marioDeath);
        marioSounds.Add(flagPoleSound);

        mario = new Mario(this, entities, marioSounds, textureManager, gameTime);

        startScreenFonts = Content.Load<SpriteFont>("StartScreenFonts");
        levelScreenFonts = Content.Load<SpriteFont>("LevelScreenFonts");
        startScreenSprite = new StartScreenSprite(textureManager, startScreenFonts);
        levelScreenSprite = new LevelScreenSprite(levelScreenFonts);

        blackJackStateMachine = new BlackJackStateMachine(textureManager, fwip, startScreenFonts);
        hudManager = new HudManager(startScreenFonts, this, mario);

        marioMovementController = new PlayerMovementController();
        playerCommandControlCenter = new PlayerCommandControlCenter(mario, marioMovementController);

        gameStateMachine = new GameStateMachine();
        gameStateKeyboardController = new KeyboardController();
        gameStateMouseController = new MouseController();
        gameStateControlCenter = new GameStateControlCenter(gameStateMachine, gameStateKeyboardController, gameStateMouseController, this, startScreenSprite, levelScreenSprite, Content, blackJackStateMachine);

    }

    protected override void Update(GameTime gameTime)
    {
        gameStateKeyboardController.Update();
        gameStateMouseController.Update();

        List<IEntity> temp = entities;
        entities = sort.SortList(entities, entities.Count, temp);
        sweep.Compare(entities, entitiesRemoved, camera.position);


        blackJackStateMachine.Update();
        if (gameStateMachine.isCurrentStateRunning())
        {
            keyboardController.Update();
            keyboardControllerMovement.Update();
            marioMovementController.Update();

            levelOne.UpdateLevel(gameTime);
            camera.Follow(mario.marioPosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));


            if (IsActive)
            {

            }



            foreach (var item in fireballs)
            {
                item.Update(gameTime);
            }

            foreach (var consumedEntity in entitiesRemoved)
            {
                if (entities.Contains(consumedEntity))
                {
                    entities.Remove(consumedEntity);
                }
            }

            foreach (var number in entities)
            {
                Console.WriteLine(number);
            }

            hudManager.Update(gameTime, camera);

        }
        if (gameStateMachine.isCurrentStatOver())
        {
            this.gameOverTickTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (gameOverTickTimer > 5000)
            {
                Process.Start("Pixel-Plumbers-Fall-2024");
                Environment.Exit(0);
            }
        }

        toggleFalling.updateMarioFalling(mario);
        // Dance.Updates();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

        if (gameStateMachine.isCurrentStateStart())
        {
            startScreenSprite.Draw(spriteBatch, new Vector2(200, 200));
        }

        if (gameStateMachine.isLevelScreen())
        {
            levelScreenSprite.Draw(spriteBatch, new Vector2(200, 200));
        }

        if (gameStateMachine.isCurrentStateRunning() || gameStateMachine.isCurrentStatePaused())
        {
            if (gameStateMachine.isLevelOne())
            {


                levelOne.DrawLevel(spriteBatch, camera);
            }

            if (gameStateMachine.isLevelTwo())
            {
                // lvl2backdrop1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                // lvl2backdrop2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
                // lvl2greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                // lvl2foreground1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                // lvl2foreground2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
            }

            foreach (var item in fireballs)
            {
                item.Draw(spriteBatch);
            }

            hudManager.Draw(spriteBatch);
            blackJackStateMachine.Draw(spriteBatch);
        }
        if (gameStateMachine.isCurrentStatOver())
        {
            // spriteBatch.Draw(gameOverBackground, new Vector2(camera.position.X, camera.position.Y), Color.Black);
            spriteBatch.DrawString(startScreenFonts, "GAME OVER", new Vector2(camera.position.X + 300, camera.position.Y + 150), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }
        //Dance.Draw(spriteBatch, DanceTexture);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
