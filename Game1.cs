using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Pixel_Plumbers_Fall_2024;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    public IMario Mario;

    public Texture2D MarioTexture;
    public Vector2 MarioPosition;
    public float MarioSpeed;
    public Vector2 MarioVelocity;
    public float Gravity = 9.8f;
    public float JumpSpeed = -350f;
    public float GroundPosition;
    public float updatedMarioSpeed;

    List<ISprite> MarioSpriteList;
    
    public ISprite BigIdleRightMario;
    public ISprite BigIdleLeftMario;
    public ISprite BigRunRightMarioAnimation;
    public ISprite BigRunLeftMarioAnimation;
    public ISprite BigJumpRightMario;
    public ISprite BigJumpLeftMario;

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

    public ISprite CurrentMarioSprite;

    public Boolean FacingRight = true;
    public Boolean MovingRight = false;
    public Boolean MovingLeft = false;
    public Boolean IsJumping = false;

   
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
    private KeyboardController controller;
    private List<ISprite> sprite1;
    public int index1 = 0;
    public int n1;
    //private List<ISprite> sprite2;
    //public int index2 = 0;
    //public int n2;

    private KeyboardController keyboardController;
    private CommandControlCenter controlCenter;
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
        MarioVelocity = Vector2.Zero;

        keyboardController = new KeyboardController();
        CurrentMarioSprite = BigIdleRightMario;
        
        Mario = new Mario(this);
        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);

        controlCenter = new CommandControlCenter(this);


        //Make a list for block iteration
        sprite1 = new List<ISprite>
            {
                //new BrokenBrickBlockSprite(),
                //new LuckyBlockSprite(),
                //new UsedBlockSprite(),
                new block1(block)
            };
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
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 150f;

        MarioTexture = Content.Load<Texture2D>("mario");
        EnemyTexture = Content.Load<Texture2D>("enemies");
        ItemsTexture = Content.Load<Texture2D>("MarioItems");
        block = Content.Load<Texture2D>("blocks");

        
        BigIdleRightMario = new BigIdleRightMario(MarioTexture);
        BigIdleLeftMario = new BigIdleLeftMario(MarioTexture);
        BigJumpRightMario = new BigJumpRightMario(MarioTexture);
        BigJumpLeftMario = new BigJumpLeftMario(MarioTexture);

        BigRunRightMarioAnimation = new BigRunRightMario(MarioTexture);
        BigRunRightMarioAnimation.Load(graphics);

        BigRunLeftMarioAnimation = new BigRunLeftMario(MarioTexture);
        BigRunLeftMarioAnimation.Load(graphics);

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




    }


    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update(gameTime);
        updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

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

        keyboardController.Update(gameTime);
        updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (MarioPosition.Y >= GroundPosition)
        {
            MarioPosition.Y = GroundPosition;
            MarioVelocity.Y = 0;
            IsJumping = false;
        }

        //moving temporarily to test
        MarioVelocity.Y += Gravity;
        MarioPosition.Y += MarioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        CurrentMarioSprite.Update(gameTime);
        spriteEnemy.Updates();
        controlG.Update(gameTime);
        manager.updateCurrentItem(currentItem, numItems);
        sprite1[index1].Update(gameTime);
        //sprite2[index2].Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteEnemy.Draw(spriteBatch, EnemyTexture);
        spriteBatch.Begin();
        CurrentMarioSprite.Draw(spriteBatch, MarioPosition);
        manager.draw(currentItem, ItemsTexture, spriteBatch, itemsPos);
        spriteBatch.End();

        // lucky block sprites
        OWLuckyBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UWLuckyBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UGLuckyBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        CastleLuckyBlockSprite.Draw(spriteBatch, new Vector2(400, 240));

        // used block sprites
        OWUsedBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UWUsedBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UGUsedBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        CastleUsedBlockSprite.Draw(spriteBatch, new Vector2(400, 240));

        // brick block sprites
        OWBrickBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UWBrickBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        UGBrickBlockSprite.Draw(spriteBatch, new Vector2(400, 240));
        CastleBrickBlockSprite.Draw(spriteBatch, new Vector2(400, 240));

        // broken brick sprites
        OWBrokenBrickSprite.Draw(spriteBatch, new Vector2(400, 240));
        UWBrokenBrickSprite.Draw(spriteBatch, new Vector2(400, 240));
        UGBrokenBrickSprite.Draw(spriteBatch, new Vector2(400, 240));
        CastleBrokenBrickSprite.Draw(spriteBatch, new Vector2(400, 240));
        //sprite1[index2].Draw(spriteBatch, new Vector2(0,0));
        //sprite2[index2].Draw(spriteBatch, new Vector2(0,0));
        base.Draw(gameTime);
    }
}
