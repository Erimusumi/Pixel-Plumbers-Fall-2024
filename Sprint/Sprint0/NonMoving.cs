using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class NonMoving : ISprite
{

    Rectangle sourceRectangle;
    Rectangle destinationRectangle;
    int counter = 0;


    public void Updates()
    {
        counter++;
        if (counter == 1)
        {
            sourceRectangle = new Rectangle(205, 51, 22, 34);
            destinationRectangle = new Rectangle(320, 180, 125, 125);
        }
        if (counter == 5)
        {
            sourceRectangle = new Rectangle(266, 51, 22, 34);
            destinationRectangle = new Rectangle(320, 180, 125, 125);
        }
        if (counter == 10)
        {
            sourceRectangle = new Rectangle(296, 51, 22, 34);
            destinationRectangle = new Rectangle(320, 180, 125, 125);
        }
        if(counter == 15)
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