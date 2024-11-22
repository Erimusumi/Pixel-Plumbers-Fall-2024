using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class PlayerBlockInteraction
{
    private IPlayer player;
    private IBlock block;
    private Rectangle marioRect;
    private Rectangle blockRect;
    public Boolean isLuckyBlock;

    public PlayerBlockInteraction(IPlayer player, IBlock block, Boolean isLuckyBlock)
    {
        this.mario = mario;
        this.block = block;
        marioRect = mario.GetDestination();
        blockRect = block.GetDestination();
        this.isLuckyBlock = isLuckyBlock;
    }

    // Method to handle Mario and Block collision
    public void update()
    {
        // Calculate overlap distances
        float overlapLeft = marioRect.Right - blockRect.Left;
        float overlapRight = blockRect.Right - marioRect.Left;
        float overlapTop = marioRect.Bottom - blockRect.Top;
        float overlapBottom = blockRect.Bottom - marioRect.Top;

        // Determine the smallest overlap to find the collision side
        float minOverlap = Math.Min(Math.Min(overlapLeft, overlapRight), Math.Min(overlapTop, overlapBottom));

        if (minOverlap == overlapTop)
        {
            // Collision from the top
            mario.marioPosition.Y = blockRect.Top - marioRect.Height;
            mario.SetVelocityY(0); // Mario stands on top of the obstacle
            mario.isOnGround = true;
            mario.jumpStop();
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom (Mario jumps into the obstacle)
            mario.marioPosition.Y = blockRect.Bottom;
            mario.SetVelocityY(0); // Prevent Mario from going higher

            if (block is LuckyBlockSprite luckyBlock)
            {
                luckyBlock.bump = true;
                
            }
            
            
        }
        else if (minOverlap == overlapLeft)
        {
            // Collision from the left
            mario.marioPosition.X = blockRect.Left - marioRect.Width;
            mario.SetVelocityX(0); // Stop horizontal movement
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            mario.marioPosition.X = blockRect.Right;
            mario.SetVelocityX(0); // Stop horizontal movement
        }
    }

    private void StopMarioHorizontalMovement()
    {
        mario.SetVelocityX(0);
    }

    private void StopMarioVerticalMovement()
    {
        // Set Mario's vertical velocity to 0
        mario.SetVelocityY(0);
    }
}