using System;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;

public class singleFrameWithMoving : ISprite
{
    private Rectangle frames;
    private int currentFrame;
    private float elapsedTime;
    private float timePerFrame;
    private Rectangle destinationRectangle;
    private Color color;

    //added for moving
    private float verticalSpeed;
    private float maxVerticalOffset;
    private float verticalOffset;
    private Vector2 startPosition;

    public singleFrameWithMoving()
    {
        currentFrame = 0;
        elapsedTime = 0f;
        timePerFrame = 0.12f;
        
        color = Color.White;
        frames = new Rectangle(0, 16, 15, 14);

        //added for moving
        verticalSpeed = 50f;
        maxVerticalOffset = 150f;
        verticalOffset = 0f;
        startPosition = new Vector2(340, 150);
        destinationRectangle = new Rectangle((int)startPosition.X, (int)startPosition.Y, 100, 100);
    }
    public void Update(GameTime gameTime)
    {
        // Update vertical offset
        verticalOffset += verticalSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Check if vertical offset exceeds the maximum limit and reverse direction if necessary
        if (Math.Abs(verticalOffset) >= maxVerticalOffset)
        {
            verticalSpeed = -verticalSpeed; // Reverse direction
        }

        // Update destinationRectangle with the vertical offset
        destinationRectangle.Y = (int)(startPosition.Y + verticalOffset);

    }
    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {

        // TODO: Add your drawing code herex
        spriteBatch.Draw(texture, destinationRectangle, frames, color); 
    }
}
