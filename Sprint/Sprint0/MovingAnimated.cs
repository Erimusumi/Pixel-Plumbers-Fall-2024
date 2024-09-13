using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class MovingAnimated : ISprite
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
        if (counter == 15)
        {
            sourceRectangle = new Rectangle(266, 51, 22, 34);
            destinationRectangle = new Rectangle(400, 180, 125, 125);
        }
        if (counter == 20)
        {
            sourceRectangle = new Rectangle(296, 51, 22, 34);
            destinationRectangle = new Rectangle(480, 180, 125, 125);
        }

        if (counter == 27)
        {
            sourceRectangle = new Rectangle(325, 51, 22, 34);
            destinationRectangle = new Rectangle(480, 180, 125, 125);
        }
        if (counter == 37)
        {
            sourceRectangle = new Rectangle(146, 51, 22, 34);
            destinationRectangle = new Rectangle(340, 180, 125, 125);
        }
        if (counter == 50)
        {
            sourceRectangle = new Rectangle(56, 51, 22, 34);
            destinationRectangle = new Rectangle(290, 180, 125, 125);
        }
        if (counter == 60)
        {
            sourceRectangle = new Rectangle(266, 51, 22, 34);
            destinationRectangle = new Rectangle(320, 180, 125, 125);
        }

        if (counter == 80)
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