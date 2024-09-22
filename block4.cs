using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2_Test;


public class block4 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;

    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(172, 236, 80, 81);
        destinationRectangle = new Rectangle(410, 150, 80, 81);
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D block)
    {
        spriteBatch.Draw(block, destinationRectangle, sourceRectangle, Color.White);
    }
}
