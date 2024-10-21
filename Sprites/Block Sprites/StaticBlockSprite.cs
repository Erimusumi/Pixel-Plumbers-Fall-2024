using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
public class StaticBlockSprite: IBlock
{
    public Texture2D texture { get; set; }
    public Rectangle rectangle { get; set; }
    private Rectangle destinationRectangle;
    public StaticBlockSprite(Texture2D texture, Rectangle sourceRectangle)
    {
        this.texture = texture;
        this.rectangle = sourceRectangle;
    }
    public void Update(GameTime gametime)
    {

    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 28, 28);
        //spriteBatch.Begin();
        spriteBatch.Draw(texture, destinationRectangle, rectangle, Color.White);
        //spriteBatch.End();
    }
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
    public void Load(GraphicsDeviceManager graphics)
    {

    }
}

