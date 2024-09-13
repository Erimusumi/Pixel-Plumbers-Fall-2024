using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class AnimatedeLeftRightSprite : ISprite
{
    public Vector2 Position;
    private Texture2D marioTexture;

    private int Screenwidth;
    private float GameTicks;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    Rectangle[] RightFrameRectangles;
    Rectangle[] LeftFrameRectangles;
    public bool right = true;

    public AnimatedeLeftRightSprite(Texture2D marioTexture)
    {
        this.marioTexture = marioTexture;
    }

    public void Draw(GraphicsDeviceManager _graphics, SpriteBatch _spriteBatch)
    {
        Rectangle sourceRectangle = new Rectangle(0, 0, 48, 64);
        if (right)
        {
            _spriteBatch.Draw(marioTexture, Position, RightFrameRectangles[currentAnimationIndex], Color.White);
        }
        else
        {
            _spriteBatch.Draw(marioTexture, Position, LeftFrameRectangles[currentAnimationIndex], Color.White);
        }
    }

    public void LoadContent(GraphicsDeviceManager _graphics)
    {
        Position.X = _graphics.PreferredBackBufferWidth / 2;
        Position.Y = _graphics.PreferredBackBufferHeight / 2;
        Screenwidth = _graphics.PreferredBackBufferWidth;

        GameTicks = 0;
        AnimationSpeed = 100;

        RightFrameRectangles = new Rectangle[3];
        RightFrameRectangles[0] = new Rectangle(239, 52, 16, 32);
        RightFrameRectangles[1] = new Rectangle(270, 52, 14, 31);
        RightFrameRectangles[2] = new Rectangle(299, 53, 16, 30);

        LeftFrameRectangles = new Rectangle[3];
        LeftFrameRectangles[0] = new Rectangle(150, 52, 16, 32);
        LeftFrameRectangles[1] = new Rectangle(121, 52, 14, 31);
        LeftFrameRectangles[2] = new Rectangle(90, 53, 16, 30);

        previousAnimationIndex = 2;
        currentAnimationIndex = 1;
    }

    public void Update(GameTime gameTime)
    {
        if (GameTicks > AnimationSpeed)
        {
            if (right)
            {
                if (Position.X >= Screenwidth)
                {
                    right = false;
                }
                else
                {
                    Position.X += 10;
                }
            }
            else
            {
                if (Position.X <= 0)
                {
                    right = true;
                }
                else
                {
                    Position.X -= 10;
                }
            }
            if (currentAnimationIndex == 1)
            {
                if (previousAnimationIndex == 0)
                {
                    currentAnimationIndex = 2;
                }
                else
                {
                    currentAnimationIndex = 0;
                }
                previousAnimationIndex = currentAnimationIndex;
            }
            else
            {
                currentAnimationIndex = 1;
            }
            GameTicks = 0;
        }
        else
        {
            GameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}