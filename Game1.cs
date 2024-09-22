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
        MarioPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,
                                   graphics.PreferredBackBufferHeight / 2);
        MarioSpeed = 200f;
        MarioTexture = Content.Load<Texture2D>("mario");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                             Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float updatedBallSpeed = MarioSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Up))
        {
            MarioPosition.Y -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            MarioPosition.Y += updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            MarioPosition.X -= updatedBallSpeed;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            MarioPosition.X += updatedBallSpeed;
        }

        if (MarioPosition.X > graphics.PreferredBackBufferWidth - MarioTexture.Width / 2)
        {
            MarioPosition.X = graphics.PreferredBackBufferWidth - MarioTexture.Width / 2;
        }
        else if (MarioPosition.X < MarioTexture.Width / 2)
        {
            MarioPosition.X = MarioTexture.Width / 2;
        }

        if (MarioPosition.Y > graphics.PreferredBackBufferHeight - MarioTexture.Height / 2)
        {
            MarioPosition.Y = graphics.PreferredBackBufferHeight - MarioTexture.Height / 2;
        }
        else if (MarioPosition.Y < MarioTexture.Height / 2)
        {
            MarioPosition.Y = MarioTexture.Height / 2;
        }

        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();
        spriteBatch.Draw(
        MarioTexture,
        MarioPosition,
        null,
        Color.White,
        0f,
        new Vector2(MarioTexture.Width / 2, MarioTexture.Height / 2),
        Vector2.One,
        SpriteEffects.None,
        0f
        );

        spriteBatch.End();
        base.Draw(gameTime);
    }
}
