using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class CheepsSprites
{
    private int LeftPosX1;
    private int LeftPosX2;
    private int RightPosX1;
    private int RightPosX2;
    //0 is red, 1 is green, 2 is white
    public CheepsSprites(int color)
    {
        switch (color)
        {
            case 0:
                LeftPosX1 = 0;
                LeftPosX2 = 30;
                RightPosX1 = 60;
                RightPosX1 = 90;
                break;
            case 1:
                LeftPosX1 = 120;
                LeftPosX2 = 150;
                RightPosX1 = 180;
                RightPosX1 = 210;
                break;
            case 2:
                LeftPosX1 = 240;
                LeftPosX2 = 270;
                RightPosX1 = 300;
                RightPosX1 = 330;
                break;
        }
    } 
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private int counter = -1;

    private const int countEnd = 400;
    private const int countStart = 10;
    private const int countMod = 10;

    private const int posX = 480;
    private const int posY = 400;
    private const int SourceHeight = 184;
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
            sourceRectangle = new Rectangle(LeftPosX2, SourceHeight, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position - speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(LeftPosX1, SourceHeight, size, size);
            } else
            {
                sourceRectangle = new Rectangle(LeftPosX2, SourceHeight, size, size);
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
            sourceRectangle = new Rectangle(RightPosX2, SourceHeight, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position + speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(RightPosX1, SourceHeight, size, size);
            }
            else
            {
                sourceRectangle = new Rectangle(RightPosX2, SourceHeight, size, size);
            }
        }
        destinationRectangle = new Rectangle(position, posY, size * scaleUp, size * scaleUp);
        if (counter >= countEnd)
        {
            counter = -1;
            position = posX;
        }
    }
	public void StompedLogic()	{  }
	public void FlippedLogic()
	{
        rotation = 3.1415926535f;
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(RightPosX2, SourceHeight, size, size);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(RightPosX1, SourceHeight, size, size);
            }
            else
            {
                sourceRectangle = new Rectangle(RightPosX2, SourceHeight, size, size);
            }
        }
        if (counter >= countEnd)
        {
            counter = -1;
        }
    }
    public Rectangle GetDestination()
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
