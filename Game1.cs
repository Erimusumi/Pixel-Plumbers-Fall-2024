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

    private KeyboardController keyboardController;
    private CommandControlCenter controlCenter;
    public IMario Mario;
    
    public IMarioSprite currentMarioSprite;

    public Vector2 marioPosition;
    public Vector2 marioVelocity;

    public float marioSpeed;
    public float gravity = 9.8f;
    public float jumpSpeed = -350f;
    public float groundPosition;
    public float updatedMarioSpeed;

    public float GroundPosition;

    public Boolean facingRight = true;
    public Boolean isJumping = false;


    //Enemy Code
    ISpriteEnemy spriteEnemy;
    IController controlG;
    Texture2D EnemyTexture;

    public Texture2D ItemsTexture;
    public ISprite firePower;
    public ISprite starPower;
    public ISprite mushroom;
    Vector2 itemsPos = new Vector2(400, 250);
    ItemManager manager = new ItemManager();
    public int numItems = 3;
    public int currentItem = 0;

    //Block Code
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
    // lucky block sprites
    private ISprite OWLuckyBlockSprite;
    // used block sprites
    private ISprite OWUsedBlockSprite;
    // brick sprites
    private ISprite OWBrickBlockSprite;
    // broken brick sprites
    private ISprite OWBrokenBrickSprite;


    private IdleMarioCommand idleMarioCommand;
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        GroundPosition = graphics.PreferredBackBufferHeight / 2;
        keyboardController = new KeyboardController();

        Mario = new Mario(this, marioTexture);
        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);

        controlCenter = new CommandControlCenter(this, marioTexture);

        idleMarioCommand = new IdleMarioCommand(this, marioTexture);

        //Make a list for block iteration
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

            marioSpeed = 10;
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

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        marioTexture = Content.Load<Texture2D>("mario");
        EnemyTexture = Content.Load<Texture2D>("enemies");
        ItemsTexture = Content.Load<Texture2D>("MarioItems");
        block = Content.Load<Texture2D>("blocks");
        obstacle = Content.Load<Texture2D>("obstacle");

        currentMarioSprite = new IdleLeftBigMario(marioTexture);
        marioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        //currentMarioState = MarioState.Big;

        firePower = new FirePower(ItemsTexture);
        starPower = new StarPower(ItemsTexture);

        // lucky block sprites
        OWLuckyBlockSprite = new LuckyBlockSprite(block, new Vector2(80, 112), new Vector2(128, 128), 3, 10);

        // used block sprites
        OWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 112, 16, 16));

        // brick block sprites
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));

        // broken brick block sprites
        OWBrokenBrickSprite = new BrokenBrickBlockSprite(block, new Vector2(288, 112), new Vector2(352, 128), 4, 1);

        // obstacle sprites
        obstacle1 = new block1(obstacle);
        obstacle2 = new Block2(obstacle);
        obstacle3 = new Block3(obstacle);
        obstacle4 = new Block4(obstacle);
    }

    protected override void Update(GameTime gameTime)
    {

        
        keyboardController.Update();

        updatedMarioSpeed = marioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        marioVelocity.Y += gravity;
        marioPosition.Y += marioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (marioPosition.Y >= GroundPosition)
        {
            marioPosition.Y = GroundPosition;
            marioVelocity.Y = 0;
            isJumping = false;
        }
        currentMarioSprite.Update(gameTime);
        
        Mario.Update();

        // lucky block sprites
        OWLuckyBlockSprite.Update(gameTime);

        // broken brick block sprites
        if (IsActive)
        {
            OWBrokenBrickSprite.Update(gameTime);
        }

        spriteEnemy.Updates();
        controlG.Update();
        manager.updateCurrentItem(currentItem, numItems);
        sprite1[index1].Update(gameTime);
        sprite2[index2].Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // mari and enemy
        spriteEnemy.Draw(spriteBatch, EnemyTexture);
        spriteBatch.Begin();
        manager.draw(currentItem, ItemsTexture, spriteBatch, itemsPos);
        currentMarioSprite.Draw(spriteBatch, marioPosition);
        spriteBatch.End();


        sprite1[index1].Draw(spriteBatch, new Vector2(40,10));
        sprite2[index2].Draw(spriteBatch, new Vector2(0,0));

        base.Draw(gameTime);
    }
}
