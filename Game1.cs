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


    private KeyboardController keyboardController;
    private KeyboardControllerMovement keyboardControllerMovement;
    private CommandControlCenter controlCenter;


    private Mario mario;
    private PlayerMovementController marioMovementController;
    private PlayerCommandControlCenter playerCommandControlCenter;




    // public IMario Mario;
    // The New Mario

    //Enemy Code
    public ISpriteEnemy spriteEnemy;
    public IController controlG;
    Texture2D EnemyTexture;

    public Texture2D ItemsTexture;
    public ISprite firePower;
    public ISprite starPower;
    public ISprite mushroom;
    Vector2 itemsPos = new Vector2(400, 250);
    public ItemManager manager = new ItemManager();
    public int numItems = 3;
    public int currentItem = 0;

    //Block Code instance variables
    private Texture2D block;
    private Texture2D obstacle;
    private List<ISprite> sprite1;
    public int index1;
    public int n1;
    private List<ISprite> sprite2;
    public int index2;
    public int n2;
    private ISprite obstacle1;
    private ISprite obstacle2;
    private ISprite obstacle3;
    private ISprite obstacle4;
    private ISprite OWLuckyBlockSprite;
    private ISprite OWUsedBlockSprite;
    private ISprite OWBrickBlockSprite;
    private ISprite OWBrokenBrickSprite;

    private ISprite StartText;
    private SpriteFont MyFont;

    // reset instances
    public Vector2 initial_mario_position;
    private bool gameStarted = false;
    private bool gamePaused = false;
    private bool gameReset = true;

    // private IdleMarioCommand idleMarioCommand;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void ResetGame()
    {
        spriteEnemy = new Goomba(); // Create a new Goomba object
        controlG = new GoombaCommand(spriteEnemy); // Reset Goomba's control command
        currentItem = 0;
        index1 = 0;
        index2 = 0;
        gameReset = false;  // Ensure reset only happens once per key press
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();


        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);

        controlCenter = new CommandControlCenter(this);

        // idleMarioCommand = new IdleMarioCommand(this, marioTexture);

        //Make a first list for block iteration
        sprite1 = new List<ISprite>
            {
                //lucky brick sprites
                OWLuckyBlockSprite,
                //broekn brick sprites
                OWBrokenBrickSprite,
                //brick sprites
                OWBrickBlockSprite,
                //used block sprites
                OWUsedBlockSprite
            };

        sprite2 = new List<ISprite>
        {
            obstacle1,
            obstacle2,
            obstacle3,
            obstacle4
        };

        n1 = sprite1.Count;
        n2 = sprite2.Count;
        index1 = 0;
        index2 = 0;

    }
    public ISpriteEnemy SetEnemy(ISpriteEnemy enemy)
    {
        spriteEnemy = enemy;
        return spriteEnemy;
    }
    public void SetEnemyCommand(IController Enemy)
    {
        controlG = Enemy;
    }
    public void SetKey(KeyboardController keys)
    {
        keyboardController = keys;
    }
    public void SetKeyMovement(KeyboardControllerMovement keys)
    {
        keyboardControllerMovement = keys;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        marioTexture = Content.Load<Texture2D>("mario");
        EnemyTexture = Content.Load<Texture2D>("enemies");
        ItemsTexture = Content.Load<Texture2D>("itemsAndPowerups");
        MyFont = Content.Load<SpriteFont>("MyFont");
        StartText = new StartScreenText(MyFont);

        block = Content.Load<Texture2D>("blocks");
        obstacle = Content.Load<Texture2D>("obstacle");

        mario = new Mario(marioTexture, new GameTime());
        marioMovementController = new PlayerMovementController();
        playerCommandControlCenter = new PlayerCommandControlCenter(mario, marioMovementController);

        // Reset instances initialization

        firePower = new FirePower(ItemsTexture);
        starPower = new StarPower(ItemsTexture);

        // Initialize block and obstacle sprites
        OWLuckyBlockSprite = new LuckyBlockSprite(block, 3, 20);
        OWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 112, 16, 16));
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        OWBrokenBrickSprite = new BrokenBrickBlockSprite(block, 4, 1);
        obstacle1 = new obstacle1(obstacle);
        obstacle2 = new obstacle2(obstacle);
        obstacle3 = new obstacle3(obstacle);
        obstacle4 = new obstacle4(obstacle);
    }


    protected override void Update(GameTime gameTime)
    {

        if (Keyboard.GetState().IsKeyDown(Keys.D0))
        {
            gameStarted = true;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.D8))
        {
            if (gamePaused)
            {
                gamePaused = false;
            }
            else
            {
                gamePaused = true;
            }
        }
        if (gamePaused)
        {
            return;
        }

        if (Keyboard.GetState().IsKeyDown(Keys.D9))
        {
            gameReset = true;
            gameStarted = false;
        }

        if (gameReset)
        {
            ResetGame();
        }

        if (gameStarted)
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
            controlG.Update();
            manager.updateCurrentItem(ref currentItem, numItems);

            //Update block and obstacle sprites
            sprite1[index1].Update(gameTime);
            sprite2[index2].Update(gameTime);
        }


        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);



        if (gameStarted)
        {
            // mari and enemy
            spriteEnemy.Draw(spriteBatch, EnemyTexture);
            spriteBatch.Begin();
            mario.Draw(spriteBatch);
            manager.draw(currentItem, ItemsTexture, spriteBatch, itemsPos);
            spriteBatch.End();

            // Draw blocks and obstacles
            sprite1[index1].Draw(spriteBatch, new Vector2(200, 200));
            sprite2[index2].Draw(spriteBatch, new Vector2(310, 150));
        }
        else
        {
            spriteBatch.Begin();
            StartText.Draw(spriteBatch, new Vector2(200, 200));

            spriteBatch.End();
        }

        base.Draw(gameTime);
    }
}
