using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StarPower: ISprite
{
    private Texture2D ItemTexture;
    private Rectangle destinationRectangle;
    public StarPower(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 48, 15, 15);
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);
        spriteBatch.Draw(ItemTexture, destinationRectangle, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
}