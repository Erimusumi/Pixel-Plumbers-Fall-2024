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

    // lucky block sprites
    private ISprite OWLuckyBlockSprite;
    private ISprite UWLuckyBlockSprite;
    private ISprite UGLuckyBlockSprite;
    private ISprite CastleLuckyBlockSprite;

    // used block sprites
    private ISprite OWUsedBlockSprite;
    private ISprite UWUsedBlockSprite;
    private ISprite UGUsedBlockSprite;
    private ISprite CastleUsedBlockSprite;

    // brick sprites
    private ISprite OWBrickBlockSprite;
    private ISprite UWBrickBlockSprite;
    private ISprite UGBrickBlockSprite;
    private ISprite CastleBrickBlockSprite;

    // broken brick sprites
    private ISprite OWBrokenBrickSprite;
    private ISprite UWBrokenBrickSprite;
    private ISprite UGBrokenBrickSprite;
    private ISprite CastleBrokenBrickSprite;



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
                UWLuckyBlockSprite,
                UGLuckyBlockSprite,
                CastleLuckyBlockSprite,
                //broekn brick sprites
                OWBrokenBrickSprite,
                UWBrokenBrickSprite,
                UGBrokenBrickSprite,
                CastleBrokenBrickSprite,
                //brick sprites
                OWBrickBlockSprite,
                UWBrickBlockSprite,
                UGBrickBlockSprite,
                CastleBrokenBrickSprite,
                //used block sprites
                OWUsedBlockSprite,
                UGUsedBlockSprite,
                UGUsedBlockSprite,
                CastleUsedBlockSprite
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
        UWLuckyBlockSprite = new LuckyBlockSprite(block, new Vector2(80, 160), new Vector2(128, 176), 3, 10);
        UGLuckyBlockSprite = new LuckyBlockSprite(block, new Vector2(80, 128), new Vector2(128, 144), 3, 10);
        CastleLuckyBlockSprite = new LuckyBlockSprite(block, new Vector2(80, 144), new Vector2(128, 160), 3, 10);

        // used block sprites
        OWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 112, 16, 16));
        UWUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 160, 16, 16));
        UGUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 128, 16, 16));
        CastleUsedBlockSprite = new StaticBlockSprite(block, new Rectangle(128, 144, 16, 16));

        // brick block sprites
        OWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 112, 16, 16));
        UWBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 160, 16, 16));
        UGBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 128, 16, 16));
        CastleBrickBlockSprite = new StaticBlockSprite(block, new Rectangle(272, 144, 16, 16));

        // broken brick block sprites
        OWBrokenBrickSprite = new BrokenBrickBlockSprite(block, new Vector2(288, 112), new Vector2(352, 128), 4, 1);
        UWBrokenBrickSprite = new BrokenBrickBlockSprite(block, new Vector2(288, 160), new Vector2(352, 176), 4, 1);
        UGBrokenBrickSprite = new BrokenBrickBlockSprite(block, new Vector2(288, 128), new Vector2(352, 144), 4, 1);
        CastleBrokenBrickSprite = new BrokenBrickBlockSprite(block, new Vector2(288, 144), new Vector2(352, 160), 4, 1);

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
        UWLuckyBlockSprite.Update(gameTime);
        UGLuckyBlockSprite.Update(gameTime);
        CastleLuckyBlockSprite.Update(gameTime);

        // broken brick block sprites
        if (IsActive)
        {
            OWBrokenBrickSprite.Update(gameTime);
            UWBrokenBrickSprite.Update(gameTime);
            UGBrokenBrickSprite.Update(gameTime);
            CastleBrokenBrickSprite.Update(gameTime);
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
