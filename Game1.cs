using System;
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

    public ICommand SetMovingRightMarioCommand;
    public ICommand SetMovingLeftMarioCommand;
    public ICommand SetJumpingUpMarioCommand;
    public ICommand EnemySwitch;

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
    

    private KeyboardController keyboardController;
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

        SetJumpingUpMarioCommand = new SetJumpUp(this);
        SetMovingRightMarioCommand = new SetMoveRightCommand(this);
        SetMovingLeftMarioCommand = new SetMoveLeftCommand(this);
        EnemySwitch = new EnemySwitch(this);

        keyboardController = new KeyboardController();
        keyboardController.addCommand(Keys.Right, SetMovingRightMarioCommand);
        keyboardController.addCommand(Keys.Left, SetMovingLeftMarioCommand);
        keyboardController.addCommand(Keys.Up, SetJumpingUpMarioCommand);
        keyboardController.addCommand(Keys.P, EnemySwitch);
        keyboardController.addCommand(Keys.O, EnemySwitch);

        CurrentMarioSprite = BigIdleRightMario;
        
        Mario = new Mario(this);
        spriteEnemy = new Goomba();
        controlG = new GoombaCommand(spriteEnemy);
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
