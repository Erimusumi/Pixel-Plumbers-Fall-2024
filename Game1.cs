using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D marioTexture;
    private GameTime gameTime;
    private Texture2D titleTexture;

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
    public ISpriteEnemy spriteEnemy;
    public IController controlG;
    public ISpriteEnemy spriteEnemy2;
    public IController controlG2;
    Texture2D EnemyTexture;

    //Dance
    private ISpriteAnimation Dance;
    private Texture2D DanceTexture;

    //Items
    public Texture2D ItemsTexture;
    public ISprite firePower;
    public ISprite starPower;
    public ISprite mushroomPower;
    public Fire f;
    public Star s;
    public Mushroom m;
    Vector2 itemsPos = new Vector2(400, 250);
    public ItemManager manager = new ItemManager();
    public int numItems = 3;
    public int currentItem = 0;

    //Block Code instance variables
    private Texture2D block;
    private Texture2D obstacle;

    private IObstacle obstacle1;
    private IObstacle obstacle2;
    private IObstacle obstacle3;
    private IObstacle obstacle4;
    private IBlock OWLuckyBlockSprite;
    private IBlock OWUsedBlockSprite;
    private IBlock OWBrickBlockSprite;
    private IBlock OWBrokenBrickSprite;

    //Fireballs
    public List<Fireball> fireballs = new List<Fireball>();

    private List<IEntity> entities = new List<IEntity>();
    private Sort sort = new Sort();
    private Sweep sweep = new Sweep();

    // reset instances
    public Vector2 initial_mario_position;

    // Start Screen
    private ISprite StartText;
    private SpriteFont MyFont;
    private Texture2D title;
    Rectangle screen = new Rectangle(0, 0, 800, 480);

    // map layers
    private Layer backdrop;
    private Layer greenery;
    private Layer foreground;

    private StartScreenText startScreenText;
    // tile sheets
    private Texture2D overworldTiles;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void ResetGame()
    {
        entities.Clear();
        spriteEnemy = new Goomba(480, 400);
        spriteEnemy2 = new Goomba2(240, 400);
        //spriteEnemy = new Koopa(480, 400);
        s = new Star(spriteBatch, ItemsTexture, new Vector2(240, 190));
        m = new Mushroom(spriteBatch, ItemsTexture, new Vector2(440, 190));
        entities.Add(spriteEnemy2);
        entities.Add(spriteEnemy);
        entities.Add(mario);
        entities.Add(m);
        entities.Add(OWLuckyBlockSprite);
        entities.Add(OWBrickBlockSprite);
        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);

        controlG = new GoombaCommand(spriteEnemy);
        controlG2 = new GoombaCommand(spriteEnemy2);
        currentItem = 0;
        fireballs.Clear();
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();

        // map layers
        backdrop = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Backdrop.csv");
        greenery = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Greenery.csv");
        foreground = new Layer(32, 16, 17, Content.RootDirectory + "/level1_Foreground.csv");

        // load map layers
        backdrop.LoadLayer();
        greenery.LoadLayer();
        foreground.LoadLayer();

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();

        spriteEnemy = new Goomba(530, 400);
        spriteEnemy2 = new Goomba2(240, 400);
        //spriteEnemy = new Koopa(480, 400);
        s = new Star(spriteBatch, ItemsTexture, new Vector2(440, 190));
        m = new Mushroom(spriteBatch, ItemsTexture, new Vector2(440, 190));
        OWLuckyBlockSprite = new LuckyBlockSprite(block, 3, 20);
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        obstacle1 = new obstacle1(obstacle);
        obstacle2 = new obstacle2(obstacle);
        obstacle3 = new obstacle3(obstacle);

        entities.Add(spriteEnemy2);
        entities.Add(spriteEnemy);
        entities.Add(mario);
        entities.Add(m);
        entities.Add(OWLuckyBlockSprite);
        entities.Add(OWBrickBlockSprite);
        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);

        controlG = new GoombaCommand(spriteEnemy);
        controlG2 = new GoombaCommand(spriteEnemy2);
        controlCenter = new CommandControlCenter(this);

        Dance = new DancePole();

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
        MyFont = Content.Load<SpriteFont>("MyFont");
        StartText = new StartScreenText(MyFont);
        title = Content.Load<Texture2D>("title");

        // tilesheet
        overworldTiles = Content.Load<Texture2D>("OverworldTiles");

        block = Content.Load<Texture2D>("blocks");
        obstacle = Content.Load<Texture2D>("obstacle");

        mario = new Mario(marioTexture, gameTime, this, entities);
        marioMovementController = new PlayerMovementController();
        playerCommandControlCenter = new PlayerCommandControlCenter(mario, marioMovementController);

        gameStateMachine = new GameStateMachine();

        startScreenText = new StartScreenText(MyFont);
        gameStateKeyboardController = new KeyboardController();
        gameStateMouseController = new MouseController();
        gameStateControlCenter = new GameStateControlCenter(gameStateMachine, gameStateKeyboardController, gameStateMouseController, this, startScreenText);
        // Reset instances initialization
        firePower = new FirePower(ItemsTexture);
        starPower = new StarPower(ItemsTexture);
        mushroomPower = new MushroomPower(ItemsTexture);


        // Initialize block and obstacle sprites
        //OWLuckyBlockSprite = new LuckyBlockSprite(block, 3, 20);
        OWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 112, 16, 16));
        //OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        OWBrokenBrickSprite = new UnknownBlockSprite(block, 4, 1);
        obstacle4 = new obstacle4(obstacle);
    }

    protected override void Update(GameTime gameTime)
    {
        gameStateKeyboardController.Update();
        gameStateMouseController.Update();

        List<IEntity> temp = entities;
        entities = sort.SortList(entities, entities.Count, temp);
        sweep.Compare(entities, screen);

        if (gameStateMachine.isCurrentStateRunning())
        {
            keyboardController.Update();
            keyboardControllerMovement.Update();
            marioMovementController.Update();

            // Update Mario's state
            mario.Update(gameTime);


            // lucky block sprites
            OWLuckyBlockSprite.Update(gameTime);
            // broken brick block sprites
            if (IsActive)
            {
                OWBrokenBrickSprite.Update(gameTime);
            }

            spriteEnemy.Updates();
            //spriteEnemy2.Updates();

            //Dance.Updates();
            controlG.Update();
            manager.updateCurrentItem(ref currentItem, numItems);

            //Update block and obstacle sprites
            OWLuckyBlockSprite.Update(gameTime);
            OWBrickBlockSprite.Update(gameTime);
            obstacle1.Update(gameTime);
            obstacle2.Update(gameTime);
            obstacle3.Update(gameTime);

            foreach (var item in fireballs)
            {
                item.Update(gameTime);
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // draw map
        backdrop.Draw(spriteBatch, overworldTiles);
        greenery.Draw(spriteBatch, overworldTiles);
        foreground.Draw(spriteBatch, overworldTiles);

        if (gameStateMachine.isCurrentStateStart())
        {
            spriteBatch.Begin();
            StartText.Draw(spriteBatch, new Vector2(200, 200));
            spriteBatch.Draw(title, new Rectangle(20, 20, 176, 88), new Rectangle(1, 60, 176, 88), Color.White);
            spriteBatch.End();
        }
        if (gameStateMachine.isCurrentStateRunning() || gameStateMachine.isCurrentStatePaused())
        {
            // mari and enemy
            //Dance.Draw(spriteBatch, DanceTexture);
            spriteBatch.Begin();
            spriteEnemy.Draw(spriteBatch, EnemyTexture);
            //spriteEnemy2.Draw(spriteBatch, EnemyTexture);
            mario.Draw(spriteBatch);
            manager.draw(currentItem, ItemsTexture, spriteBatch, itemsPos);

            foreach (var item in fireballs)
            {
                item.Draw(spriteBatch);
            }

            // Draw blocks and obstacles
            OWLuckyBlockSprite.Draw(spriteBatch, new Vector2(200, 200));
            OWBrickBlockSprite.Draw(spriteBatch, new Vector2(200, 360));

            obstacle1.Draw(spriteBatch, new Vector2(350, 370));
            obstacle2.Draw(spriteBatch, new Vector2(350 + 80, 350));
            obstacle3.Draw(spriteBatch, new Vector2(350 + 350, 335));
            m.draw(); //draw mush collision test
            spriteBatch.End();
            
            
        }
        base.Draw(gameTime);
    }
}
