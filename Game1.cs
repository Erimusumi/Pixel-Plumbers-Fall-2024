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
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D marioTexture;
    private GameTime gameTime;
    private Texture2D titleTexture;

    private HudManager hudManager;

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

    //Enemy Code
    //Goomba 1 will be spriteEnemy
    public ISpriteEnemy spriteEnemy;
    public ISpriteEnemy spriteEnemy2;
    public ISpriteEnemy spriteEnemyBloop;

    //Enemy list:
    private ISpriteEnemy _Goomba2;
    private ISpriteEnemy Goomba3;
    private ISpriteEnemy Goomba4;
    private ISpriteEnemy Goomba5;
    private ISpriteEnemy Goomba6;
    private ISpriteEnemy Goomba7;
    private ISpriteEnemy Goomba8;
    private ISpriteEnemy Koopa1;
    private ISpriteEnemy Goomba9;
    private ISpriteEnemy Goomba10;
    private ISpriteEnemy Goomba11;
    private ISpriteEnemy Goomba12;
    private ISpriteEnemy Goomba13;
    private ISpriteEnemy Goomba14;
    private ISpriteEnemy Goomba15;
    private ISpriteEnemy Goomba16;

    Texture2D EnemyTexture;

    //Dance
    private ISpriteAnimation Dance;
    private Texture2D DanceTexture;

    //Items
    public Texture2D ItemsTexture;
    public ISprite firePower;
    public ISprite starPower;
    public ISprite mushroomPower;
    public Fire fire1;
    public Star star1;
    public Mushroom mushroom1;
    Vector2 itemsPos = new Vector2(400, 250);
   

    //Block Code instance variables
    private Texture2D block;
    private Texture2D obstacle;

    private IObstacle obstacle1;
    private IObstacle obstacle2;
    private IObstacle obstacle3;
    private IObstacle obstacle4;
    private IBlock OWLuckyBlockSprite;
    private IBlock OWLuckyBlockSprite2;
    private IBlock OWUsedBlockSprite;
    private IBlock OWBrickBlockSprite;
    private IBlock OWBrokenBrickSprite;

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
    SoundEffect marioJumpSound;
    SoundEffect marioDeathSound;

    List<SoundEffect> marioSoundEffects;

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
    List<Rectangle> emptyFloorRectangles;
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
        spriteEnemy = new Goomba(480, 400);
        spriteEnemy2 = new Goomba2(240, 400);

        star1 = new Star(spriteBatch, ItemsTexture);
        mushroom1 = new Mushroom(spriteBatch, ItemsTexture);
        //fire1 = new Fire(spriteBatch, ItemsTexture);
        entities.Add(spriteEnemy2);
        entities.Add(spriteEnemy);
        entities.Add(mario);
        entities.Add(OWLuckyBlockSprite);
        entities.Add(OWBrickBlockSprite);
        entities.Add(OWBrokenBrickSprite);
        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);
        entities.Add(star1);
        entities.Add(mushroom1);
        entities.Add(fire1);

      
        fireballs.Clear();
        mario.Reset();
        camera = new(Vector2.Zero);
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();
        this.sweep = new Sweep(gameTime);

        // map layers
        lvl1backdrop = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Backdrop.csv");
        lvl1greenery = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Greenery.csv");
        lvl1foreground = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Foreground.csv");

        lvl2backdrop1 = new Layer(32, 16, 17, Content.RootDirectory + "/level2_OWBackdrop.csv");
        lvl2backdrop2 = new Layer(32, 16, 17, Content.RootDirectory + "/level2_UWBackdrop.csv");
        lvl2greenery = new Layer(32, 16, 17, Content.RootDirectory + "/level2_OWGreenery.csv");
        lvl2foreground1 = new Layer(32, 16, 17, Content.RootDirectory + "/level2_OWForeground.csv");
        lvl2foreground2 = new Layer(32, 16, 17, Content.RootDirectory + "/level2_UWForeground.csv");

        // load map layers
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

        spriteEnemy = new Goomba(535, 400);
        spriteEnemy2 = new Goomba2(240, 400);
        spriteEnemyBloop = new Blooper(240, 200, mario);
        _Goomba2 = new Goomba(1400, 400);
        Goomba3 = new Goomba(1700, 400);
        Goomba4 = new Goomba(1750, 400);
        Goomba5 = new Goomba(2500, 250);
        Goomba6 = new Goomba(2600, 120);
        Goomba7 = new Goomba(3000, 400);
        Goomba8 = new Goomba(3150, 400);
        Koopa1 = new Koopa(3320, 400);
        Goomba9 = new Goomba(3520, 400);
        Goomba10 = new Goomba(3720, 400);
        Goomba11 = new Goomba(4000, 400);
        Goomba12 = new Goomba(4050, 400);
        Goomba13 = new Goomba(4110, 400);
        Goomba14 = new Goomba(4160, 400);
        Goomba15 = new Goomba(5400, 400);
        Goomba16 = new Goomba(5550, 400);


        star1 = new Star(spriteBatch, ItemsTexture/*, new Vector2(30, 400)*/);
        mushroom1 = new Mushroom(spriteBatch, ItemsTexture);
        OWLuckyBlockSprite = new LuckyBlockSprite(block, spriteBatch, ItemsTexture, this);
        OWLuckyBlockSprite2 = new LuckyBlockSprite(block, spriteBatch, ItemsTexture, this);
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        OWBrokenBrickSprite = new BrokenBrickSprite(block, 4, 1);
        obstacle1 = new obstacle1(obstacle);
        obstacle2 = new obstacle2(obstacle);
        obstacle3 = new obstacle3(obstacle);

        entities.Add(spriteEnemy2);
        entities.Add(spriteEnemy);
        entities.Add(mario);
        entities.Add(OWLuckyBlockSprite);
        entities.Add(OWLuckyBlockSprite2);
        entities.Add(OWBrickBlockSprite);
        entities.Add(OWBrokenBrickSprite);
        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);

        controlCenter = new CommandControlCenter(this);

        Dance = new DancePole();

        //Ground Detection initialization
        emptyFloorRectangles = new List<Rectangle>(); 
        emptyFloorRectangles.Add(new Microsoft.Xna.Framework.Rectangle(320, 416, 64, 64));
        ground = new Ground(emptyFloorRectangles);
        toggleFalling = new ToggleFalling(ground,entities);
    }

    public ISpriteEnemy SetEnemy(ISpriteEnemy enemy)
    {
        spriteEnemy = enemy;
        return spriteEnemy;
    }

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
        table = Content.Load<Texture2D>("BlackJack/table");
        tabletop = Content.Load<Texture2D>("BlackJack/tabletop");
        cards = Content.Load<Texture2D>("BlackJack/cards");
        fwip = Content.Load<SoundEffect>("Audio/flip");

        startScreenFonts = Content.Load<SpriteFont>("StartScreenFonts");
        startScreenSprite = new StartScreenSprite(titleTexture, startScreenFonts);
        levelScreenFonts = Content.Load<SpriteFont>("LevelScreenFonts");
        levelScreenSprite = new LevelScreenSprite(levelScreenFonts);

        blackJackStateMachine = new BlackJackStateMachine(table, tabletop, cards, fwip, startScreenFonts);
        hudManager = new HudManager(startScreenFonts, this, mario);

        // tilesheet
        overworldTiles = Content.Load<Texture2D>("OverworldTiles");
        underwaterTiles = Content.Load<Texture2D>("UnderwaterTiles");

        block = Content.Load<Texture2D>("blocks");
        obstacle = Content.Load<Texture2D>("obstacle");

        gameStateMachine = new GameStateMachine();

        gameStateKeyboardController = new KeyboardController();
        gameStateMouseController = new MouseController();
        gameStateControlCenter = new GameStateControlCenter(gameStateMachine, gameStateKeyboardController, gameStateMouseController, this, startScreenSprite, levelScreenSprite, Content, blackJackStateMachine);
        // Reset instances initialization
        firePower = new FirePower(ItemsTexture);
        starPower = new StarPower(ItemsTexture);
        mushroomPower = new MushroomPower(ItemsTexture);

        // Initialize block and obstacle sprites

        obstacle4 = new obstacle4(obstacle);

        //SFX audios
        pipeSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_pipe");
        oneUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_1-up");
        coinSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_coin");
        fireBallSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_fireball");
        flagPoleSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_flagpole");
        powerUpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup");
        powerUpSpawnsSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_powerup_appears");
        //TODO: Replace these with correct sounds
        marioJumpSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_coin");
        marioDeathSound = Content.Load<SoundEffect>("Audio/Sound Effect(s)/smb_coin");

        marioSoundEffects =
        [
            powerUpSound, powerDownSound, fireBallSound, marioJumpSound, marioDeathSound
        ];

        mario = new Mario(marioTexture, gameTime, this, entities, marioSoundEffects);

        marioMovementController = new PlayerMovementController();
        playerCommandControlCenter = new PlayerCommandControlCenter(mario, marioMovementController);
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

            // Update Mario's state
            mario.isOnGround = false;
            mario.Update(gameTime);
            Rectangle marioBounds = mario.GetDestination();
            camera.Follow(mario.marioPosition, new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

            // lucky block sprites
            OWLuckyBlockSprite.Update(gameTime);
            // broken brick block sprites
            if (IsActive)
            {
                OWBrokenBrickSprite.Update(gameTime);
            }

            spriteEnemy.Updates();
            spriteEnemy2.Updates();
            spriteEnemyBloop.Updates();
            _Goomba2.Updates();
            Goomba3.Updates();
            Goomba4.Updates();
            Goomba5.Updates();
            Goomba6.Updates();
            Goomba7.Updates();
            Goomba8.Updates();
            Koopa1.Updates();
            Goomba9.Updates();
            Goomba10.Updates();
            Goomba11.Updates();
            Goomba12.Updates();
            Goomba13.Updates();
            Goomba14.Updates();
            Goomba15.Updates();
            Goomba16.Updates();

            //Dance.Updates();
           
            //Update block and obstacle sprites
            OWLuckyBlockSprite.Update(gameTime);
            OWLuckyBlockSprite2.Update(gameTime);
            OWBrickBlockSprite.Update(gameTime);
            OWBrokenBrickSprite.Update(gameTime);
            obstacle1.Update(gameTime);
            obstacle2.Update(gameTime);
            obstacle3.Update(gameTime);

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
        toggleFalling.updateMarioFallingTest(mario);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        if (gameStateMachine.isCurrentStateStart())
        {
            spriteBatch.Begin();
            startScreenSprite.Draw(spriteBatch, new Vector2(200, 200));

            spriteBatch.End();
        }

        if (gameStateMachine.isLevelScreen())
        {
            spriteBatch.Begin();
            levelScreenSprite.Draw(spriteBatch, new Vector2(200, 200));
            spriteBatch.End();
        }

        if (gameStateMachine.isCurrentStateRunning() || gameStateMachine.isCurrentStatePaused())
        {
            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());

            lvl1backdrop.Draw(spriteBatch, overworldTiles, Vector2.Zero);
            lvl1greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
            lvl1foreground.Draw(spriteBatch, overworldTiles, Vector2.Zero);

            //lvl2backdrop1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
            //lvl2backdrop2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
            //lvl2greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
            //lvl2foreground1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
            //lvl2foreground2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);

            spriteEnemy.Draw(spriteBatch, EnemyTexture);
            spriteEnemy2.Draw(spriteBatch, EnemyTexture);
            mario.Draw(spriteBatch);
            spriteEnemyBloop.Draw(spriteBatch, EnemyTexture);
            _Goomba2.Draw(spriteBatch, EnemyTexture);
            Goomba3.Draw(spriteBatch, EnemyTexture);
            Goomba4.Draw(spriteBatch, EnemyTexture);
            Goomba5.Draw(spriteBatch, EnemyTexture);
            Goomba6.Draw(spriteBatch, EnemyTexture);
            Goomba7.Draw(spriteBatch, EnemyTexture);
            Goomba8.Draw(spriteBatch, EnemyTexture);
            Koopa1.Draw(spriteBatch, EnemyTexture);
            Goomba9.Draw(spriteBatch, EnemyTexture);
            Goomba10.Draw(spriteBatch, EnemyTexture);
            Goomba11.Draw(spriteBatch, EnemyTexture);
            Goomba12.Draw(spriteBatch, EnemyTexture);
            Goomba13.Draw(spriteBatch, EnemyTexture);
            Goomba14.Draw(spriteBatch, EnemyTexture);
            Goomba15.Draw(spriteBatch, EnemyTexture);
            Goomba16.Draw(spriteBatch, EnemyTexture);

            foreach (var item in fireballs)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix());
            OWLuckyBlockSprite2.Draw(spriteBatch, new Vector2(200, 200));
            OWBrickBlockSprite.Draw(spriteBatch, new Vector2(200, 350));
            OWBrokenBrickSprite.Draw(spriteBatch, new Vector2(200 + 31, 350));
            OWLuckyBlockSprite.Draw(spriteBatch, new Vector2(200 + 62, 350));
            obstacle1.Draw(spriteBatch, new Vector2(350, 370));
            obstacle2.Draw(spriteBatch, new Vector2(350 + 80, 350));
            obstacle3.Draw(spriteBatch, new Vector2(350 + 350, 335));

            hudManager.Draw(spriteBatch);
            blackJackStateMachine.Draw(spriteBatch);

            spriteBatch.End();
        }
        base.Draw(gameTime);
    }
}
