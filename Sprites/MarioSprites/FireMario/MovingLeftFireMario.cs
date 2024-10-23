using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MovingLeftFireMario : IMarioSprite
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private float AnimationTicks;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;
    public MovingLeftFireMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        AnimationTimer = 0;
        AnimationTicks = 100;
        AnimationSpeed = 200;


        FrameRectangles = new Rectangle[3];
        FrameRectangles[0] = new Rectangle(180, 122, 16, 32); // Frame 1
        FrameRectangles[1] = new Rectangle(152, 122, 14, 31); // Frame 2
        FrameRectangles[2] = new Rectangle(128, 122, 16, 30);  // Frame 3

        previousAnimationIndex = 2;
        currentAnimationIndex = 1;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gameTime)
    {
        if (AnimationTimer > AnimationTicks)
        {
            currentAnimationIndex = (currentAnimationIndex == 1) ?
                                    (previousAnimationIndex == 0 ? 2 : 0) : 1;
            previousAnimationIndex = currentAnimationIndex;
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
            case 0: return new Rectangle((int)position.X, (int)position.Y, 16 * (int)scale, 32 * (int)scale);
            case 1: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 31 * (int)scale);
            case 2:
            default: return new Rectangle((int)position.X, (int)position.Y, 16 * (int)scale, 30 * (int)scale);
        }
    }
}