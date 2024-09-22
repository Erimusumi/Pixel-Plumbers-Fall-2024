using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint2_Test;


public class block3 : ISprite
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;

    public void Update(GameTime gameTime)
    {
        sourceRectangle = new Rectangle(84, 321, 62, 128);
        destinationRectangle = new Rectangle(410, 250, 62, 128);
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D block)
    {
        spriteBatch.Draw(block, destinationRectangle, sourceRectangle, Color.White);
    }
}
