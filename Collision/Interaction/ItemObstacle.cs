using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemObstacle
{
    private IEntity item;
    private IObstacle obstacle;
    private Rectangle itemRectangle;
    private Rectangle obstacleRect;
    public ItemObstacle(List<IEntity> entities,int index IObstacle obstacle)
    {
        this.item = entities[index];
        this.obstacle = obstacle;
        itemRectangle = item.GetDestination();
        obstacleRect = obstacle.GetDestination();
    }

    public void update()
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
            mario.marioVelocity.Y = 0; // Mario stands on top of the obstacle
            mario.isOnGround = true;
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom (Mario jumps into the obstacle)
            mario.marioPosition.Y = obstacleRect.Bottom;
            mario.marioVelocity.Y = 0; // Prevent Mario from going higher
        }
        else if (minOverlap == overlapLeft)
        {
            // Collision from the left
            mario.marioPosition.X = obstacleRect.Left - marioRect.Width;
            mario.marioVelocity.X = 0; // Stop horizontal movement
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            mario.marioPosition.X = obstacleRect.Right;
            mario.marioVelocity.X = 0; // Stop horizontal movement
        }
    }
}
