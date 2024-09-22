using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pixel_Plumbers_Fall_2024;
public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    Texture2D MarioTexture;
    Vector2 MarioPosition;
    float MarioSpeed;
    private Vector2 MarioVelocity;
    private float Gravity = 9.8f;
    private float JumpSpeed = -350f;
    private float GroundPosition;

    private ISprite IdleRightMario;
    private ISprite IdleLeftMario;
    private ISprite MovingRightMarioAnimation;
    private ISprite MovingLeftMarioAnimation;
    private ISprite JumpingRightMario;
    private ISprite JumpingLeftMario;

    public Boolean FacingRight = true;
    public Boolean MovingRight = false;
    public Boolean MovingLeft = true;
    private Boolean IsJumping = false;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        GroundPosition = graphics.PreferredBackBufferHeight / 2;                     // Set ground level based on screen height.
        MarioVelocity = Vector2.Zero;
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 200f;

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

        float updatedMarioSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        var kstate = Keyboard.GetState();

        MovingRight = false;
        MovingLeft = false;

        if (kstate.IsKeyDown(Keys.Left))
        {
            FacingRight = false;
            MovingLeft = true;
            MarioPosition.X -= updatedMarioSpeed;
            MovingLeftMarioAnimation.Update(gameTime);
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            FacingRight = true;
            MovingRight = true;
            MarioPosition.X += updatedMarioSpeed;
            MovingRightMarioAnimation.Update(gameTime);
        }

        if (!IsJumping && kstate.IsKeyDown(Keys.Space))
        {
            MarioVelocity.Y = JumpSpeed;  // Apply jump force
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

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
