using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingLeftSmallMario : IMarioSprite
{
    private Texture2D MarioTexture;
    private float GameTicks;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;

    public MovingLeftSmallMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        GameTicks = 0;
        AnimationSpeed = 100;

        FrameRectangles = new Rectangle[3];
        FrameRectangles[0] = new Rectangle(150, 0, 14, 15); // Frame 1
        FrameRectangles[1] = new Rectangle(121, 0, 14, 15); // Frame 2
        FrameRectangles[2] = new Rectangle(89, 0, 14, 15);  // Frame 3

        previousAnimationIndex = 2;
        currentAnimationIndex = 1;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], Color.White);
    }

    public void Update(GameTime gameTime)
    {
        GameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        if (GameTicks > AnimationSpeed)
        {
            currentAnimationIndex = (currentAnimationIndex == 1)
                ? (previousAnimationIndex == 0 ? 2 : 0)
                : 1;

            previousAnimationIndex = currentAnimationIndex;
            GameTicks = 0;
        }
    }

    public Rectangle GetDestinationRectangle(Vector2 position)
    {
        switch (currentAnimationIndex)
        {
            case 0: return new Rectangle((int)position.X, (int)position.Y, 14, 15);
            case 1: return new Rectangle((int)position.X, (int)position.Y, 14, 15);
            case 2:
            default: return new Rectangle((int)position.X, (int)position.Y, 14, 15);
        }

    }
}