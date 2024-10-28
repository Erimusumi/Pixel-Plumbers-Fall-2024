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
    private int counterLR = 0;
    private int counter = 0;

    private const int height = 16;
    private int width = 16;
    private const int scaleUp = 2;
    private const int speed = 1;

    private int minFall = 336;
    private int maxRise = 100;

    private float rotation = 0f;

    public void Rise()
    {
        width = 24;
        sourceRectangle = new Rectangle(420, 0, height, width);
        posY -= 1;
        if (counterLR == 1)
        {
            position -= speed;
        }
        else if (counterLR == 2)
        {
            position += speed;
        }

        destinationRectangle = new Rectangle(position, posY, height * scaleUp, width * scaleUp);
    }

    public void Fall()
    {
        width = 16;
        sourceRectangle = new Rectangle(390, 4, height, width);
        posY += 1;
        destinationRectangle = new Rectangle(position, posY, height * scaleUp, width * scaleUp);
    }

    public void Idle()
    {
        counter++;
        int posYBalance = 170-(minFall-posY);
        if (counter < posYBalance)
        {
            Rise();
        }
        else
        {
            Fall();
        }
        /*
        if (posY + 85 > minFall)
        {
            if (counter < posYBalance)
            {
                Rise();
            }
            else
            {
                Fall();
            }
        }else
        {
            if (counter < 85)
            {
                Fall();
            }
            else
            {
                Rise();
            }
        }
        */
        if (counter >= 170)
        {
            counter = 0;
        }
        destinationRectangle = new Rectangle(position, posY, height * scaleUp, width * scaleUp);
    }

    public void LeftLogic()
    {
        counterLR = 1;
        Idle();
        counterLR = 0;
    }
    public void RightLogic()
    {
        counterLR = 2;
        Idle();
        counterLR = 0;
    }
    public void StompedLogic()
    {
    }
    public void FlippedLogic()
    {
        rotation = 3.1415926535f;
        width = 24;
        sourceRectangle = new Rectangle(420, 0, height, width);
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
