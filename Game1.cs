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
    private Texture2D marioTexture;
    private GameTime gameTime;
    private Texture2D titleTexture;
    private Texture2D gameOverBackground;
    private float gameOverTickTimer;

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


    Texture2D EnemyTexture;

    //Dance
    private ISpriteAnimation Dance;
    private Texture2D DanceTexture;

    //Items
    public Texture2D ItemsTexture;

    //Block Code instance variables
    private Texture2D block;
    private Texture2D obstacleTexture;

    

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
    private Layer lvl1backdrop;
    private Layer lvl1greenery;
    private Layer lvl1foreground;

    private Layer lvl2backdrop1;
    private Layer lvl2backdrop2;
    private Layer lvl2greenery;
    private Layer lvl2foreground1;
    private Layer lvl2foreground2;

    // tile sheets
    private Texture2D overworldTiles;
    private Texture2D underwaterTiles;

    //Ground Detection
    Ground ground;
    ToggleFalling toggleFalling;
    List<Rectangle> collidableRectangles;
    ToggleFalling ToggleFalling;

    //Black Jack
    private Texture2D table;
    private Texture2D tabletop;
    private Texture2D cards;
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
        entities.Add(mario);

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
        Dance = new DancePole();
        
       
        lvl1backdrop = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Backdrop.csv");
        lvl1greenery = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Greenery.csv");
        lvl1foreground = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Foreground.csv");

        lvl2backdrop1 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWBackdrop.csv");
        lvl2backdrop2 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_UWBackdrop.csv");
        lvl2greenery = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWGreenery.csv");
        lvl2foreground1 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWForeground.csv");
        lvl2foreground2 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_UWForeground.csv");

        lvl1backdrop.LoadLayer();
        lvl1greenery.LoadLayer();
        lvl1foreground.LoadLayer();

        lvl2backdrop1.LoadLayer();
        lvl2backdrop2.LoadLayer();
        lvl2greenery.LoadLayer();
        lvl2foreground1.LoadLayer();
        lvl2foreground2.LoadLayer();

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();
        controlCenter = new CommandControlCenter(this);




        entities.Add(mario);

        levelOne = new LevelOne(this, entities, mario, EnemyTexture, block, ItemsTexture, obstacleTexture, spriteBatch);
        levelOne.InitializeLevel();
        List<IEntity> tempEntities = levelOne.GetAllEntities();
        entities.AddRange(tempEntities);

        //Ground Detection initialization
        collidableRectangles = new List<Rectangle>();
        collidableRectangles = lvl1foreground.GetRedRectangles();

        ground = new Ground(collidableRectangles);
        toggleFalling = new ToggleFalling(ground, entities);
    }

    // public ISpriteEnemy SetEnemy(ISpriteEnemy enemy)
    // {
    //     spriteEnemy = enemy;
    //     return spriteEnemy;
    // }

    public void SetKey(KeyboardController keys)
    {
        keyboardController = keys;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        titleTexture = Content.Load<Texture2D>("supermariobros");
        marioTexture = Content.Load<Texture2D>("mario");
        EnemyTexture = Content.Load<Texture2D>("enemies");
        DanceTexture = Content.Load<Texture2D>("dance");
        ItemsTexture = Content.Load<Texture2D>("itemsAndPowerups");
        gameOverBackground = Content.Load<Texture2D>("blank screen");
        table = Content.Load<Texture2D>("BlackJack/table");
        tabletop = Content.Load<Texture2D>("BlackJack/tabletop");
        cards = Content.Load<Texture2D>("BlackJack/cards");
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
        

        overworldTiles = Content.Load<Texture2D>("OverworldTilesv200");
        underwaterTiles = Content.Load<Texture2D>("UnderwaterTiles");

        block = Content.Load<Texture2D>("blocks");
        obstacleTexture = Content.Load<Texture2D>("obstacle");

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
        mario = new Mario(marioTexture, gameTime, this, entities, marioSounds);

        startScreenFonts = Content.Load<SpriteFont>("StartScreenFonts");
        levelScreenFonts = Content.Load<SpriteFont>("LevelScreenFonts");
        startScreenSprite = new StartScreenSprite(titleTexture, startScreenFonts);
        levelScreenSprite = new LevelScreenSprite(levelScreenFonts);

        blackJackStateMachine = new BlackJackStateMachine(table, tabletop, cards, fwip, startScreenFonts);
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
        sweep.Compare(entities, entitiesRemoved, screen);
        

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
                //OWBrokenBrickSprite.Update(gameTime);
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
                lvl1backdrop.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                lvl1greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                lvl1foreground.Draw(spriteBatch, overworldTiles, Vector2.Zero);

                levelOne.DrawLevel(spriteBatch, camera);
            }

            if (gameStateMachine.isLevelTwo())
            {
                lvl2backdrop1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                lvl2backdrop2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
                lvl2greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                lvl2foreground1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
                lvl2foreground2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
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
            spriteBatch.Draw(gameOverBackground, camera.position, Color.Black);
            spriteBatch.DrawString(startScreenFonts, "GAME OVER", new Vector2(300, 150), Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 0f);
        }
        //Dance.Draw(spriteBatch, DanceTexture);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
