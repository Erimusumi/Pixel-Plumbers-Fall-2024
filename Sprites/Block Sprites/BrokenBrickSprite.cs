using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class BrokenBrickSprite : IBlock
{
    public Texture2D Texture { get; set; }
    public Vector2 Start { get; set; }
    public Vector2 End { get; set; }
    public int numOfFrames { get; set; }
    public double waitTime { get; set; }
    private double buffer;
    private int width;
    private int height;
    private int currentFrame;
    private bool broken;
    private bool bumping;
    public bool animationDone;
    public Rectangle destinationRectangle;

    public BrokenBrickSprite(Texture2D texture, int frames, double wait)
    {
        Texture = texture;
        Start = new Vector2(288, 112);
        End = new Vector2(352, 128);
        numOfFrames = frames;
        waitTime = wait;            // the amount of time between frame changes, time per frame
        currentFrame = 0;
        buffer = 0; // total elapsed time
        width = (int)(End.X - Start.X) / frames;
        height = (int)(End.Y - Start.Y);
        this.broken = false;  // Initial state is not animating
        this.bumping = false;
    }

    public void StartAnimation()
    {
        // Method to trigger animation
        broken = true;
    }

    public void Update(GameTime gameTime)
    {
        if (bumping)
        {
            // Adjust the block's vertical position for the bump animation
            const float bumpHeight = 10f; // Height of the bump
            const float bumpSpeed = 100f; // Speed of the bump animation

            // Move block up and then back down
            buffer += gameTime.ElapsedGameTime.TotalSeconds;

            if (buffer <= bumpHeight / bumpSpeed) // Moving up
            {
                destinationRectangle.Y -= (int)(bumpSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else if (buffer <= 2 * (bumpHeight / bumpSpeed)) // Moving down
            {
                destinationRectangle.Y += (int)(bumpSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                // End the bump animation and reset
                buffer = 0;
            }
        }

        // Handle other animation frames if needed
        if (broken)
        {
            buffer += gameTime.ElapsedGameTime.TotalSeconds;

            if (buffer >= waitTime)
            {
                currentFrame++;
                buffer -= waitTime;

                // Stop animating at the last frame
                if (currentFrame >= numOfFrames-1)
                {
                    currentFrame = numOfFrames - 2; // Set to the last frame
                    broken = false; // Stop animation
                    animationDone = true;
                }
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        Rectangle sourceRectangle = new Rectangle(
            (int)Start.X + width * currentFrame,
            (int)Start.Y,
            width,
            height
        );

        destinationRectangle = new Rectangle(
            (int)location.X,
            (int)location.Y,
            31,
            31
        );

        if (!animationDone)
        {
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
        
    }

    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }

    public void Load(GraphicsDeviceManager graphics)
    {
        // Loading logic if needed
    }
    public void bump()
    {
        bumping = true;
    }
    public void broke()
    {
        broken = true;
    }
}