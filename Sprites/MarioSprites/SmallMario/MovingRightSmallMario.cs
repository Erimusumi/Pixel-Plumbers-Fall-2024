using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingRightSmallMario : IMarioSprite
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private float AnimationTicks;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;
    public MovingRightSmallMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        AnimationTimer = 0;
        AnimationTicks = 100;
        AnimationSpeed = 200;

        FrameRectangles = new Rectangle[3];
        FrameRectangles[0] = new Rectangle(241, 0, 14, 15); // Frame 1
        FrameRectangles[1] = new Rectangle(272, 0, 14, 15); // Frame 2
        FrameRectangles[2] = new Rectangle(300, 0, 14, 15);  // Frame 3

        previousAnimationIndex = 2;
        currentAnimationIndex = 1;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gameTime)
    {
        if (AnimationTimer > AnimationSpeed)
        {
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
            AnimationTimer = 0;
        }
        else
        {
            AnimationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }

    public Rectangle GetDestination(Vector2 position)
    {
        switch (currentAnimationIndex)
        {
            case 0: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 15 * (int)scale);
            case 1: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 15 * (int)scale);
            case 2:
            default: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 15 * (int)scale);
        }

    }

}