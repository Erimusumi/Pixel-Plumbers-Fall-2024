using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class NonMovingNonAnimated : ISprite
{

    Rectangle sourceRectangle;
    Rectangle destinationRectangle;

    public void Updates()
    {
        sourceRectangle = new Rectangle(205, 51, 22, 34);
        destinationRectangle = new Rectangle(320, 180, 125, 125);
    }
    public void Draw(SpriteBatch sb, Texture2D Texture)
    {
        sb.Begin();
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        sb.End();
    }
}