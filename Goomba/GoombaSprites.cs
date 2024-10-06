using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class GoombaSprites
{
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private int counter = -1;

    private const int countEnd = 400;
    private const int countStart = 10;
    private const int countMod = 10;

    private const int posX = 480;
    private const int posY = 400;
    private const int size = 16;
    private const int scaleUp = 2;
    private const int speed = 1;
    private int position = posX;

    private float rotation = 0f;


    public void LeftLogic()
	{
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(0, 4, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position - speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(30, 4, size, size);
            } else
            {
                sourceRectangle = new Rectangle(0, 4, size, size);
            }
        }
        destinationRectangle = new Rectangle(position, posY, size * scaleUp, size * scaleUp);
        if (counter >= countEnd)
        {
            counter = -1;
            position = posX;
        }

    }
	public void RightLogic()
	{
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(0, 4, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position + speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(30, 4, size, size);
            }
            else
            {
                sourceRectangle = new Rectangle(0, 4, size, size);
            }
        }
        destinationRectangle = new Rectangle(position, posY, size * scaleUp, size * scaleUp);
        if (counter >= countEnd)
        {
            counter = -1;
            position = posX;
        }
    }
	public void StompedLogic()
	{
        rotation = 0f;
        sourceRectangle = new Rectangle(60, 8, size, size/2);
        destinationRectangle = new Rectangle(position, posY+10, size * scaleUp, (size/2) * scaleUp);
    }
	public void FlippedLogic()
	{
        rotation = 3.1415926535f;
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(0, 4, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(30, 4, size, size);
            }
            else
            {
                sourceRectangle = new Rectangle(0, 4, size, size);
            }
        }
        if (counter >= countEnd)
        {
            counter = -1;
        }
    }
    public Rectangle destinationR()
    {
        return destinationRectangle;
    }
	public void Draw(SpriteBatch sb, Texture2D Texture)
	{
        sb.Begin();
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, rotation, new Vector2(size / 2, size / 2), SpriteEffects.None, 0f);
        sb.End();
    }

}
