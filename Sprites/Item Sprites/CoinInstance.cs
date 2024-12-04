using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CoinInstance : ISprite
{
    private Texture2D ItemTexture;
    private Rectangle[] frames;
    private int[] frameWidths;
    private int currentFrame;
    private int lastFrame;
    private int ticks;
    //private Vector2 position;

    public CoinInstance(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;

        frames = new Rectangle[5];
        frameWidths = new int[5];
        frames[0] = new Rectangle(2, 81, 10, 15);
        frames[1] = new Rectangle(4, 96, 5, 13);
        frames[2] = new Rectangle(18, 96, 8, 15);
        frames[3] = new Rectangle(39, 96, 2, 15);
        frames[4] = new Rectangle(55, 96, 1, 15);

        frameWidths[0] = 10;
        frameWidths[1] = 5;
        frameWidths[2] = 8;
        frameWidths[3] = 2;
        frameWidths[4] = 1;

        currentFrame = 0;
        lastFrame = 4;
        ticks = 0;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = frames[currentFrame];
        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);
        
        

    }

    public void Update(GameTime gametime)
    {
        if (ticks > 5)
        {
            ticks = 0;
            if (currentFrame >= lastFrame)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame++;
            }
        }
        ticks++;
    }
    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, frameWidths[currentFrame], 15);
    }
}