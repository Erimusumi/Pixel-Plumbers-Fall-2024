using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class animatedSpriteWithMoving : ISprite
{
    private Rectangle[] frames;
    private int currentFrame;
    private float elapsedTime;
    private float timePerFrame;
    private Rectangle destinationRectangle;
    private Color color;

    //added for movnig
    Vector2 position;
    float speed;
    bool movingRight;

    public animatedSpriteWithMoving()
    {
        currentFrame = 0;
        elapsedTime = 0f;
        timePerFrame = 0.12f;
        
        color = Color.White;
        frames = new Rectangle[14];
        frames[0] = new Rectangle(209, 52, 16, 32);
        frames[1] = new Rectangle(239, 52, 16, 32);
        frames[2] = new Rectangle(270, 52, 14, 31);
        frames[3] = new Rectangle(299, 53, 16, 30);
        frames[4] = new Rectangle(329, 52, 16, 32);
        frames[5] = new Rectangle(359, 52, 16, 32);
        frames[6] = new Rectangle(389, 57, 16, 22);
        frames[7] = new Rectangle(0, 57, 16, 22);
        frames[8] = new Rectangle(30, 52, 16, 32);
        frames[9] = new Rectangle(60, 52, 16, 32);
        frames[10] = new Rectangle(90, 53, 16, 30);
        frames[11] = new Rectangle(121, 52, 14, 31);
        frames[12] = new Rectangle(150, 52, 16, 32);
        frames[13] = new Rectangle(180, 52, 16, 32);

        //added for moving
        speed = 190f;
        position = new Vector2(340, 150);
        movingRight = true;
        destinationRectangle = new Rectangle(340, 150, 150, 150);
    }
    public void Update(GameTime gameTime)
    {
        // Update animation frame
        elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (elapsedTime >= timePerFrame)
        {
            elapsedTime = 0f;
            currentFrame++;
            if (currentFrame >= frames.Length)
            {
                currentFrame = 0; // Loop back to the first frame
            }
        }

        // Update horizontal movement
        if (movingRight)
        {
            position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (position.X > 500 - frames[0].Width) // Hit right edge
            {
                movingRight = false;
            }
        }
        else
        {
            position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (position.X < 180) // Hit left edge
            {
                movingRight = true;
            }
        }

        // Update destinationRectangle with the new position
        destinationRectangle.X = (int)position.X;
        destinationRectangle.Y = (int)position.Y;

    }
    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {

        // TODO: Add your drawing code herex
        spriteBatch.Draw(texture, destinationRectangle, frames[currentFrame], color);
    }
}
