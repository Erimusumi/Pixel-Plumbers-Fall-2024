using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SwimmingLeftBigLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D LuigiTexture;
    private float AnimationTicks;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int previousAnimationIndex;
    private int currentAnimationIndex;
    private Color tint;

    private Rectangle[] FrameRectangles;
    public SwimmingLeftBigLuigi(Texture2D LuigiTexture)
    {
        this.LuigiTexture = LuigiTexture;

        AnimationTimer = 0;
        AnimationTicks = 100;
        AnimationSpeed = 200;

        FrameRectangles = new Rectangle[6];
        FrameRectangles[0] = new Rectangle(180, 88, 16, 29); // Frame 1
        FrameRectangles[1] = new Rectangle(152, 88, 16, 29); // Frame 2
        FrameRectangles[2] = new Rectangle(127, 88, 16, 29);  // Frame 3
        FrameRectangles[3] = new Rectangle(103, 88, 14, 30); // Frame 4
        FrameRectangles[4] = new Rectangle(78, 88, 14, 30); // Frame 5
        FrameRectangles[5] = new Rectangle(52, 88, 16, 30);  // Frame 6

        currentAnimationIndex = 0;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        spriteBatch.Draw(LuigiTexture, position, FrameRectangles[currentAnimationIndex], tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gameTime)
    {
        if (AnimationTimer > AnimationSpeed)
        {
            if (currentAnimationIndex == 5)
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
            case 1:
            case 2:
            return new Rectangle((int)position.X, (int)position.Y, 16 * (int)scale, 29 * (int)scale);
            case 3: 
            case 4: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 30 * (int)scale);
            case 5:
            default: return new Rectangle((int)position.X, (int)position.Y, 14 * (int)scale, 29 * (int)scale);
        }
    }
}