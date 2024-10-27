using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlooperSprites
{
    private int posY = 0;
    private int position = 0;
    private Mario mario;
    public BlooperSprites(int _posX, int _posY, Mario mario)
    {
        position = _posX;
        posY = _posY;
        this.mario = mario;
    }

    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Rectangle marioDestination;
    private int counter = -1;
    private int counter2 = 0;
    private int counterLR = 0;

    private const int countStart = 10;
    private const int countMod = 10;

    private const int height = 16;
    private int width = 16;
    private const int scaleUp = 2;
    private const int speed = 1;

    private int ground = 400;

    private float rotation = 0f;

    private void Rise()
    {
        width = 16;
        sourceRectangle = new Rectangle(390, 4, height, width);
        posY -= 1;
        if ((counter2 > 0) && (counter2 <= countStart))
        {
            if (counterLR == 1)
            {
                position -= speed;
            }
            else if (counterLR == 2)
            {
                position += speed;
            }
        }
    }

    private void Fall()
    {
        width = 24;
        sourceRectangle = new Rectangle(420, 0, height, width);
        posY += 1;
    }

    private void Idle()
    {
        counter++;
        if (counter < 85)
        {
            Rise();
        } else
        {
            Fall();
        }
        if (counter == 170)
        {
            counter = 0;
        }
        destinationRectangle = new Rectangle(position, posY, height * scaleUp, width * scaleUp);
    }

    public void LeftLogic()
    {
        //marioDestination = mario.GetDestination();
        counter2++;
        counterLR = 1;
        if (counter2 > countStart)
        {
            counter2 = 0;
        }
        Idle();
    }
    public void RightLogic()
    {
        counter2++;
        counterLR = 2;
        if (counter2 > countStart)
        {
            counter2 = 0;
        }
        Idle();
    }
    public void StompedLogic()
    {

    }
    public void FlippedLogic()
    {
        rotation = 3.1415926535f;
        counter++;
        if (counter == 0)
        {
            width = 16;
            sourceRectangle = new Rectangle(0, 4, height, width);
        }
        if (counter >= countStart)
        {
            if (counter % countMod < (countMod / 2))
            {
                width = 24;
                sourceRectangle = new Rectangle(30, 4, height, width);
            }
            else
            {
                width = 16;
                sourceRectangle = new Rectangle(0, 4, height, width);
            }
        }
    }
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
    public void Draw(SpriteBatch sb, Texture2D Texture)
    {
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, rotation, new Vector2(height / 2, width / 2), SpriteEffects.None, 0f);
    }

}
