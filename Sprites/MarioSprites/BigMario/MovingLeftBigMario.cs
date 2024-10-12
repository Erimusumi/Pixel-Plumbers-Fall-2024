using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingLeftBigMario : IMarioSprite
{
    private Texture2D MarioTexture;
    private float GameTicks;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;
    public MovingLeftBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        GameTicks = 0;
        AnimationSpeed = 100;

        FrameRectangles = new Rectangle[3];
        FrameRectangles[0] = new Rectangle(150, 52, 16, 32); // Frame 1
        FrameRectangles[1] = new Rectangle(121, 52, 14, 31); // Frame 2
        FrameRectangles[2] = new Rectangle(90, 53, 16, 30);  // Frame 3

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

        if (GameTicks <= AnimationSpeed) return;

        currentAnimationIndex = currentAnimationIndex == 1
            ? (previousAnimationIndex == 0 ? 2 : 0)
            : 1;

        previousAnimationIndex = currentAnimationIndex;
        GameTicks = 0;
    }

    public Rectangle GetDestinationRectangle(Vector2 position)
    {
        switch (currentAnimationIndex)
        {
            case 0: return new Rectangle((int)position.X, (int)position.Y, 16, 32);
            case 1: return new Rectangle((int)position.X, (int)position.Y, 14, 31);
            case 2:
            default: return new Rectangle((int)position.X, (int)position.Y, 16, 30);
        }
        
    }
}