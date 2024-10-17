using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FirePower : ISprite
{
    private Texture2D ItemTexture;
    //private Vector2 position;
    
    public FirePower(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 33, 15, 15);
       
        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);
     
    }

    public void Update(GameTime gametime)
    {
    }
    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, 15, 15);
    }
}