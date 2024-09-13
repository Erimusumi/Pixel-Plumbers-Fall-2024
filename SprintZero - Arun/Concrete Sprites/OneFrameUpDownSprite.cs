using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class OneFrameUpDown : ISprite
{
    public Vector2 Position;
    private Texture2D marioTexture;

    private bool flying = true;
    private int ScreenHeight;
    private float GameTicks;
    private int AnimationSpeed;

    public OneFrameUpDown(Texture2D marioTexture)
    {
        this.marioTexture = marioTexture;
    }

    public void Draw(GraphicsDeviceManager _graphics, SpriteBatch _spriteBatch)
    {
        if (flying)
        {
            Rectangle FrameRectangle = new Rectangle(390, 88, 14, 30);
            _spriteBatch.Draw(marioTexture, Position, FrameRectangle, Color.White);

        }
        else
        {
            Rectangle FrameRectangle = new Rectangle(209, 88, 16, 29);
            _spriteBatch.Draw(marioTexture, Position, FrameRectangle, Color.White);
        }
    }

    public void LoadContent(GraphicsDeviceManager _graphics)
    {
        Position.X = _graphics.PreferredBackBufferWidth / 2;
        Position.Y = _graphics.PreferredBackBufferHeight / 2;
        ScreenHeight = _graphics.PreferredBackBufferHeight;

        GameTicks = 0;
        AnimationSpeed = 10;
    }

    public void Update(GameTime gameTime)
    {
        {
            if (GameTicks > AnimationSpeed)
            {

                if (flying)
                {
                    if (Position.Y >= ScreenHeight)
                    {
                        flying = false;
                    }
                    Position.Y += 10;
                }
                else
                {
                    if (Position.Y <= ScreenHeight / 100)
                    {
                        flying = true;
                    }
                    Position.Y -= 10;
                }
                GameTicks = 0;
            }
            else
            {
                GameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
    }
}
