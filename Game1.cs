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

    public IMario Mario;

    public Texture2D MarioTexture;
    public Vector2 MarioPosition;
    public float MarioSpeed;
    public Vector2 MarioVelocity;
    public float Gravity = 9.8f;
    public float JumpSpeed = -350f;
    public float GroundPosition;
    public float updatedMarioSpeed;

    

    public ISprite BigIdleRightMario;
    public ISprite BigIdleLeftMario;
    public ISprite BigRunRightMarioAnimation;
    public ISprite BigRunLeftMarioAnimation;
    public ISprite BigJumpRightMario;
    public ISprite BigJumpLeftMario;

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
    Vector2 itemsPos = new Vector2(100, 500);
    ItemManager manager = new ItemManager();
    public int numItems = 3;
    public int currentItem = 0;

    //Block Code
    private Texture2D block;
    private KeyboardController controller;
    private List<ISprite> sprite1;
    public int index1 = 0;
    public int n1;
    private List<ISprite> sprite2;
    public int index2 = 0;
    public int n2;

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
        controlCenter = new CommandControlCenter(this);

        CurrentMarioSprite = BigIdleRightMario;
        
        Mario = new Mario(this);
        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);

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




    }


    protected override void Update(GameTime gameTime)
    {
        if (!IsJumping && FacingRight)
        {
            CurrentMarioSprite = BigIdleRightMario;
        }
        else if (!IsJumping && !FacingRight)
        {
            CurrentMarioSprite = BigIdleLeftMario;
        }

        keyboardController.Update(gameTime);
        updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        MarioVelocity.Y += Gravity;
        MarioPosition.Y += MarioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (MarioPosition.Y >= GroundPosition)
        {
            MarioPosition.Y = GroundPosition;
            MarioVelocity.Y = 0;
            IsJumping = false;
        }
        CurrentMarioSprite.Update(gameTime);
        spriteEnemy.Updates();
        controlG.Update(gameTime);
        manager.updateCurrentItem(currentItem, numItems);
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
        base.Draw(gameTime);
    }
}
