using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FirePower
{
    private Texture2D ItemTexture;
    private SpriteBatch sb;
    private Vector2 position;
    private Rectangle destinationRectangle;
    
    public FirePower(SpriteBatch spriteBatch, Texture2D ItemTexture, Vector2 position)
    {
        this.ItemTexture = ItemTexture;
        this.sb = spriteBatch;
        this.position = position;
    }
    public void update(GameTime gametime)
    {
    }
    public void draw()
    {
        Rectangle sourceRectangle = new Rectangle(0, 33, 16, 16);
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);
        sb.Draw(ItemTexture, destinationRectangle, sourceRectangle, Color.White);
     
    }

    
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
}