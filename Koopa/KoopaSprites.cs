using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class KoopaSprites
{
	private Rectangle sourceRectangle;
	private Rectangle destinationRectangle;
	private int counter = -1;
    private int counter2 = -1;
    private const int countEnd = 4000;
	private const int countStart = 10;
	private const int countMod = 10;
	private const int posX = 480;
	private const int posY = 400;
    private const int scaleUp = 2;
	private const int speed = 1;
	private int position = posX;
	private float rotation = 0f;

    private int width = 16;
    private int height = 24;
    private int leftXOne = 180;
    private int leftXTwo = 150;
    private int rightY = 0;
    private int rightXOne = 210;
    private int rightXTwo = 240;


    public void LeftLogic()
	{

        counter2 = -1;
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(leftXOne, rightY, width, height);
            destinationRectangle = new Rectangle(posX, posY, width*scaleUp, height*scaleUp);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position - speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(leftXTwo, rightY, width, height);
            } else
            {
                sourceRectangle = new Rectangle(leftXOne, rightY, width, height);
            }
            destinationRectangle = new Rectangle(position, posY, width * scaleUp, height * scaleUp);
        }
        if (counter >= countEnd)
        {
            counter = -1;
            position = posX;
        }

    }
	public void RightLogic()
	{
        counter2 = -1;
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(rightXOne, rightY, width, height);
            destinationRectangle = new Rectangle(posX, posY, width * scaleUp, height * scaleUp);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            position = position + speed;
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(rightXTwo, rightY, width, height);
            }
            else
            {
                sourceRectangle = new Rectangle(rightXOne, rightY, width, height);
            }
            destinationRectangle = new Rectangle(position, posY, width * scaleUp, height * scaleUp);
        }
        if (counter >= countEnd)
        {
            counter = -1;
            position = posX;
        }
    }
	public void StompedLogic()
	{
        counter2++;
        if (counter2 == 0)
        {
            sourceRectangle = new Rectangle(360, 5, 16, 15);
            destinationRectangle = new Rectangle(position, posY + 20, 16 * scaleUp, 15 * scaleUp);
        }
        if (counter2 == 200)
        {
            sourceRectangle = new Rectangle(330, 4, 16, 15);
            destinationRectangle = new Rectangle(position, posY + 20, 16 * scaleUp, 15 * scaleUp);
        }
        if ((counter2 == 350) || (counter >= countEnd))
        {
            counter = -1;
        }
    }
    public void StompedTwiceLogicLeft()
    {
        counter2 = 0;
        int holdHeight = height;
        int holdLeftXOne = leftXOne;
        int holdLeftXTwo = leftXTwo;
        int holdrightY = rightY;
        height = 15;
        leftXOne = 360;
        leftXTwo = 360;
        rightY = 5;
        this.LeftLogic();
        height = holdHeight;
        leftXOne = holdLeftXOne;
        leftXTwo = holdLeftXTwo;
        rightY = holdrightY;

    }
    public void StompedTwiceLogicRight()
    {
        counter2 = 0;
        int holdHeight = height;
        int holdRightXOne = rightXOne;
        int holdRightXTwo = rightXTwo;
        int holdrightY = rightY;
        height = 15;
        rightXOne = 360;
        rightXTwo = 360;
        rightY = 5;
        this.RightLogic();
        height = holdHeight;
        rightXOne = holdRightXOne;
        rightXTwo = holdRightXTwo;
        rightY = holdrightY;

    }
    public void FlippedLogic()
	{
        rotation = 3.1415926535f;
        counter++;
        if (counter == 0)
        {
            sourceRectangle = new Rectangle(180, 0, width, height);
        }
        if ((counter >= countStart) && (counter < countEnd))
        {
            if (counter % countMod < (countMod / 2))
            {
                sourceRectangle = new Rectangle(150, 0, width, height);
            }
            else
            {
                sourceRectangle = new Rectangle(180, 4, width, height);
            }
        }
        if (counter >= countEnd)
        {
            counter = -1;
        }
    }
	public void Draw(SpriteBatch sb, Texture2D Texture)
	{
        sb.Begin();
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, rotation, new Vector2(width / 2, height / 2), SpriteEffects.None, 0f);
        sb.End();
    }
}
