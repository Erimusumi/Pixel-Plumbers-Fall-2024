using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
using System;

public class MarioObstacleInteraction
{
    private Mario mario;
    private IObstacle obstacle;
    private Rectangle marioRect;
    private Rectangle obstacleRect;
    private GameTime gameTime; // Store GameTime for gravity application

    private bool wasOnTop = false; // Track if Mario was on top of the obstacle

    public MarioObstacleInteraction(Mario mario, IObstacle obstacle, GameTime gameTime)
    {
        this.mario = mario;
        this.obstacle = obstacle;
        this.gameTime = gameTime; // Store the GameTime reference
        marioRect = mario.GetDestination();
        obstacleRect = obstacle.GetDestination();
    }

    public void update() // Changed method name to PascalCase
    {

        // Calculate overlap distances
        float overlapLeft = marioRect.Right - obstacleRect.Left;
        float overlapRight = obstacleRect.Right - marioRect.Left;
        float overlapTop = marioRect.Bottom - obstacleRect.Top;
        float overlapBottom = obstacleRect.Bottom - marioRect.Top;

        // Determine the smallest overlap to find the collision side
        float minOverlap = Math.Min(Math.Min(overlapLeft, overlapRight), Math.Min(overlapTop, overlapBottom));

        if (minOverlap == overlapTop)
        {
            // Collision from the top
            mario.marioPosition.Y = obstacleRect.Top - marioRect.Height;
            mario.SetVelocityY(0); // Mario stands on top of the obstacle
            mario.isOnGround = true;
            wasOnTop = true; // Mario is on the obstacle
            mario.jumpStop();
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom (Mario jumps into the obstacle)
            mario.marioPosition.Y = obstacleRect.Bottom;
            mario.SetVelocityX(0); // Prevent Mario from going higher
        }
        else if (minOverlap == overlapLeft)
        {
            // Collision from the left
            mario.marioPosition.X = obstacleRect.Left - marioRect.Width;
            mario.SetVelocityX(0); // Stop horizontal movement
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            mario.marioPosition.X = obstacleRect.Right;
            mario.SetVelocityX(0); // Stop horizontal movement
        }
        if (!marioRect.Intersects(obstacleRect))
        {
            // Mario is no longer colliding with the obstacle from the top
            if (wasOnTop)
            {
                mario.isOnGround = false; // Mario is no longer on the obstacle
                wasOnTop = false;
            }
        }

        // If Mario is not on the obstacle, apply gravity
        if (!mario.isOnGround)
        {
            mario.ApplyGravity(gameTime); // Use the stored GameTime reference
        }
    }
}