using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pixel_Plumbers_Fall_2024;
public class Game1 : Game
{
    internal int CurrentMarioSprite1;
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D MarioTexture;
    public Vector2 MarioPosition;
    private float MarioSpeed;
    private Vector2 MarioVelocity;
    private float Gravity = 9.8f;
    private float JumpSpeed = -350f;
    private float GroundPosition;
    public float updatedMarioSpeed;

    public ISprite IdleRightMario;
    public ISprite IdleLeftMario;
    public ISprite MovingRightMarioAnimation;
    public ISprite MovingLeftMarioAnimation;
    public ISprite JumpingRightMario;
    public ISprite JumpingLeftMario;

    public ISprite CurrentMarioSprite;

    public Boolean FacingRight = true;
    public Boolean MovingRight = false;
    public Boolean MovingLeft = true;
    public Boolean IsJumping = false;

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
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 150f;

        MarioTexture = Content.Load<Texture2D>("mario");
        IdleRightMario = new IdleRightMario(MarioTexture);
        IdleLeftMario = new IdleLeftMario(MarioTexture);
        JumpingRightMario = new JumpingRightMario(MarioTexture);
        JumpingLeftMario = new JumpingLeftMario(MarioTexture);

        MovingRightMarioAnimation = new MovingRightMario(MarioTexture);
        MovingRightMarioAnimation.Load(graphics);

        MovingLeftMarioAnimation = new MovingLeftMario(MarioTexture);
        MovingLeftMarioAnimation.Load(graphics);
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        var kstate = Keyboard.GetState();

        MovingRight = false;
        MovingLeft = false;

        if (kstate.IsKeyDown(Keys.Left))
        {

        }
        if (kstate.IsKeyDown(Keys.Right))
        {
            FacingRight = true;
            MovingRight = true;
            MarioPosition.X += updatedMarioSpeed;
            if (!IsJumping)
            {
                MovingRightMarioAnimation.Update(gameTime);
            }
        }
        if (!IsJumping && kstate.IsKeyDown(Keys.Space))
        {
            MarioVelocity.Y = JumpSpeed;
            IsJumping = true;
        }

        MarioVelocity.Y += Gravity;
        MarioPosition.Y += MarioVelocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (MarioPosition.Y >= GroundPosition)
        {
            MarioPosition.Y = GroundPosition;                       // Snap Mario to the ground
            MarioVelocity.Y = 0;                                    // Reset vertical velocity
            IsJumping = false;                                      // Allow jumping again
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();




        if (IsJumping)
        {
            if (FacingRight)
            {
                JumpingRightMario.Draw(spriteBatch, MarioPosition);
            }
            else
            {
                JumpingLeftMario.Draw(spriteBatch, MarioPosition);
            }
        }
        else
        {
            if (FacingRight)
            {
                if (MovingRight)
                {
                    MovingRightMarioAnimation.Draw(spriteBatch, MarioPosition);
                }
                else
                {
                    IdleRightMario.Draw(spriteBatch, MarioPosition);
                }
            }

            if (!FacingRight)
            {
                if (MovingLeft)
                {
                    MovingLeftMarioAnimation.Draw(spriteBatch, MarioPosition);
                }
                else
                {
                    IdleLeftMario.Draw(spriteBatch, MarioPosition);
                }
            }
        }

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
