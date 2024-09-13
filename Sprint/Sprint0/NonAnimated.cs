using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class NonAnimated : ISprite
{

    Rectangle sourceRectangle;
    Rectangle destinationRectangle;
    int counter = 0;


    public void Updates()
    {
        counter++;
        if (counter == 1)
        {
            sourceRectangle = new Rectangle(387, 13, 18, 18);
            destinationRectangle = new Rectangle(320, 180, 125, 125);
        }
        if (counter == 20)
        {
            sourceRectangle = new Rectangle(387, 13, 18, 18);
            destinationRectangle = new Rectangle(320, 110, 125, 125);
        }
        if (counter == 25)
        {
            sourceRectangle = new Rectangle(387, 13, 18, 18);
            destinationRectangle = new Rectangle(320, 60, 125, 125);
        }
        
        if (counter == 30)
        {
            sourceRectangle = new Rectangle(387, 13, 18, 18);
            destinationRectangle = new Rectangle(320, 40, 125, 125);
        }
        
        if (counter == 35)
        {
            sourceRectangle = new Rectangle(387, 13, 18, 18);
            destinationRectangle = new Rectangle(320, 110, 125, 125);
        }
        if (counter == 40)
        {
            counter = 0;
        }
    }

    public void Draw(SpriteBatch sb, Texture2D Texture)
    {
        sb.Begin();
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        sb.End();
    }
}