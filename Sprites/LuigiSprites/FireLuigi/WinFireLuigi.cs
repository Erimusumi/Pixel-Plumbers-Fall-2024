using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WinFireLuigi : ICharacter
{
    private float scale = 2f;
    private Texture2D LuigiTexture;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int currentAnimationIndex = 0;
    private Color tint;

    private Rectangle[] FrameRectangles;

    public WinFireLuigi(Texture2D LuigiTexture)
    {
        this.LuigiTexture = LuigiTexture;

        AnimationTimer = 0;
        AnimationSpeed = 10;

        FrameRectangles = new Rectangle[2];
        FrameRectangles[0] = new Rectangle(363, 159, 14, 27); // Frame 1
        FrameRectangles[1] = new Rectangle(390, 158, 14, 30); // Frame 2

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
            if (currentAnimationIndex == 1)
            {
                currentAnimationIndex = 0;
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
        return new Rectangle((int)position.X, (int)position.Y, FrameRectangles[currentAnimationIndex].Width * (int)scale, FrameRectangles[currentAnimationIndex].Height * (int)scale);
    }
}