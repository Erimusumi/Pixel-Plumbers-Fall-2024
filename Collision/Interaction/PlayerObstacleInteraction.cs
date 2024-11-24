using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
using System;

public class PlayerObstacleInteraction
{
    private IPlayer player;
    private IObstacle obstacle;
    private Rectangle marioRect;
    private Rectangle obstacleRect;
    private GameTime gameTime; // Store GameTime for gravity application

    private bool wasOnTop = false; // Track if Mario was on top of the obstacle

    public PlayerObstacleInteraction(IPlayer player, IObstacle obstacle, GameTime gameTime)
    {
        this.player = player;
        this.obstacle = obstacle;
        this.gameTime = gameTime; // Store the GameTime reference
        marioRect = player.GetDestination();
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
            player.SetPositionY(obstacleRect.Top - marioRect.Height);
            player.SetVelocityY(0); // Mario stands on top of the obstacle
            player.SetIsOnGround(true);
            wasOnTop = true; // Mario is on the obstacle
            player.JumpStop();
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom (Mario jumps into the obstacle)
            player.SetPositionY(obstacleRect.Bottom);
            player.SetVelocityX(0); // Prevent Mario from going higher
        }
        else if (minOverlap == overlapLeft)
        {
            // Collision from the left
            player.SetPositionX(obstacleRect.Left - marioRect.Width);
            player.SetVelocityX(0); // Stop horizontal movement
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            player.SetPositionX(obstacleRect.Right);
            player.SetVelocityX(0); // Stop horizontal movement
        }
        
        if (!marioRect.Intersects(obstacleRect))
        {
            // Mario is no longer colliding with the obstacle from the top
            if (wasOnTop)
            {
                player.SetIsOnGround(false); // Mario is no longer on the obstacle
                wasOnTop = false;
            }
        }

        // If Mario is not on the obstacle, apply gravity
        if (!player.GetIsOnGround())
        {
            player.ApplyGravity(gameTime); // Use the stored GameTime reference
        }
    }
}