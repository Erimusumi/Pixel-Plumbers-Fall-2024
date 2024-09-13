using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class animatedSpriteWithFixedPosition : ISprite
{
    private Rectangle[] frames;
    private int currentFrame;
    private float elapsedTime;
    private float timePerFrame;
    private Rectangle destinationRectangle;
    private Color color;

    public animatedSpriteWithFixedPosition()
    {
        currentFrame = 0;
        elapsedTime = 0f;
        timePerFrame = 0.12f;
        destinationRectangle = new Rectangle(310, 150, 150, 150);
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
    }
    public void Update(GameTime gameTime)
    {
        elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (elapsedTime >= timePerFrame)
        {
            elapsedTime = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
        }

    }
    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {

        // TODO: Add your drawing code herex
        spriteBatch.Draw(texture, destinationRectangle, frames[currentFrame], color);
    }
}
