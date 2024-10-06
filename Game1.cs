using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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


    // public IMario Mario;
    // The New Mario
    private Mario mario;

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

    // reset instances
    public Vector2 initial_mario_position;

    // private IdleMarioCommand idleMarioCommand;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        this.gameTime = new GameTime();

        keyboardController = new KeyboardController();
        keyboardControllerMovement = new KeyboardControllerMovement();
        mario = new Mario(marioTexture, gameTime);

        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);

        controlCenter = new CommandControlCenter(this, marioTexture, mario);

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
        block = Content.Load<Texture2D>("blocks");
        obstacle = Content.Load<Texture2D>("obstacle");


        //reset instances initialization

        //currentMarioState = MarioState.Big;

        firePower = new FirePower(ItemsTexture);
        starPower = new StarPower(ItemsTexture);

        // lucky block sprites
        OWLuckyBlockSprite = new LuckyBlockSprite(block, 3, 20);
        // used block sprites
        OWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 112, 16, 16));
        // brick block sprites
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        // broken brick block sprites
        OWBrokenBrickSprite = new BrokenBrickBlockSprite(block, 4, 1);
        // obstacle sprites
        obstacle1 = new obstacle1(obstacle);
        obstacle2 = new obstacle2(obstacle);
        obstacle3 = new obstacle3(obstacle);
        obstacle4 = new obstacle4(obstacle);
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update();
        keyboardControllerMovement.Update();



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
        mario.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // mari and enemy
        spriteEnemy.Draw(spriteBatch, EnemyTexture);
        spriteBatch.Begin();
        mario.Draw(spriteBatch);
        manager.draw(currentItem, ItemsTexture, spriteBatch, itemsPos);
        spriteBatch.End();

        // Draw blocks and obstacles
        sprite1[index1].Draw(spriteBatch, new Vector2(200, 200));
        sprite2[index2].Draw(spriteBatch, new Vector2(310, 150));

        base.Draw(gameTime);
    }
}
