using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class singleFrameWithFixedPosition : ISprite
{

    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;

    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(209, 52, 16, 32);
        destinationRectangle = new Rectangle(310, 150, 150, 150);
    }
    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {
        // TODO: Add your drawing code herex
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
    }
}
