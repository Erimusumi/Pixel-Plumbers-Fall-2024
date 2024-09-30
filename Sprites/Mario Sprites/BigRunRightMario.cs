using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BigRunRightMario : ISprite
{
    private Texture2D MarioTexture;
    private float GameTicks;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;
    public BigRunRightMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        GameTicks = 0;
        AnimationSpeed = 100;

        FrameRectangles = new Rectangle[3];
        FrameRectangles[0] = new Rectangle(239, 52, 16, 32);
        FrameRectangles[1] = new Rectangle(270, 52, 14, 31);
        FrameRectangles[2] = new Rectangle(299, 53, 16, 30);

        previousAnimationIndex = 2;
        currentAnimationIndex = 1;
    }

    public void Update(GameTime gameTime)
    {
        if (GameTicks > AnimationSpeed)
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
            GameTicks = 0;
        }
        else
        {
            GameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }
}