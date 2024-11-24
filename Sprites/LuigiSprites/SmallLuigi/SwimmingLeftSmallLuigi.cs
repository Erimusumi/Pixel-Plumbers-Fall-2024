using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SwimmingLeftSmallLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private float AnimationTicks;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int previousAnimationIndex;
    private int currentAnimationIndex;
    private Color tint;

    private Rectangle[] FrameRectangles;
    public SwimmingLeftSmallLuigi(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        AnimationTimer = 0;
        AnimationTicks = 100;
        AnimationSpeed = 200;

        FrameRectangles = new Rectangle[4];
        FrameRectangles[0] = new Rectangle(180, 30, 15, 15); // Frame 1
        FrameRectangles[1] = new Rectangle(150, 30, 14, 15); // Frame 2
        FrameRectangles[2] = new Rectangle(120, 30, 14, 15);  // Frame 3
        FrameRectangles[3] = new Rectangle(90, 30, 14, 15); // Frame 4

        currentAnimationIndex = 0;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gameTime)
    {
        if (AnimationTimer > AnimationSpeed)
        {
            if (currentAnimationIndex == 3)
            {
                currentAnimationIndex = 0;
            }
            else
            {
                currentAnimationIndex++;
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
            case 0:
            return new Rectangle((int)position.X, (int)position.Y, 15 * (int)scale, 15 * (int)scale);
            case 1:
            case 2:
            case 3:
            default: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 15 * (int)scale);
        }
    }
}