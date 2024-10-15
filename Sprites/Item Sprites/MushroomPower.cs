using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MushroomPower: ISprite
{
    private Texture2D ItemTexture;
    private Vector2 position;
    public MushroomPower(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 0, 15, 15);
        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
    public Rectangle GetDestination()
    {
        return new Rectangle((int)position.X, (int)position.Y, 15, 15);
    }
}
