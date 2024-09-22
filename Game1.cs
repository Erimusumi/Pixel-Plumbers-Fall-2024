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

    private ISprite IdleRightMario;
    private ISprite IdleLeftMario;
    private ISprite MovingRightMarioAnimation;
    private ISprite MovingLeftMarioAnimation;

    public Boolean FacingRight = true;
    public Boolean MovingRight = false;
    public Boolean MovingLeft = true;


    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 200f;

        MarioTexture = Content.Load<Texture2D>("mario");
        IdleRightMario = new IdleRightMario(MarioTexture);
        IdleLeftMario = new IdleLeftMario(MarioTexture);

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

        if (kstate.IsKeyDown(Keys.Up))
        {
            MarioPosition.Y -= updatedMarioSpeed;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            MarioPosition.Y += updatedMarioSpeed;
        }

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

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
