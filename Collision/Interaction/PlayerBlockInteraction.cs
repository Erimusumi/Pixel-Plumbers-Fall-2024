using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

public class PlayerBlockInteraction
{
    private IPlayer player;
    private IBlock block;
    private Rectangle playerRect;
    private Rectangle blockRect;
    public Boolean isLuckyBlock;

    public PlayerBlockInteraction(IPlayer player, IBlock block, Boolean isLuckyBlock)
    {
        this.player = player;
        this.block = block;
        playerRect = player.GetDestination();
        blockRect = block.GetDestination();
        this.isLuckyBlock = isLuckyBlock;
    }

    // Method to handle player and Block collision
    public void update()
    {
        // Calculate overlap distances
        float overlapLeft = playerRect.Right - blockRect.Left;
        float overlapRight = blockRect.Right - playerRect.Left;
        float overlapTop = playerRect.Bottom - blockRect.Top;
        float overlapBottom = blockRect.Bottom - playerRect.Top;

        // Determine the smallest overlap to find the collision side
        float minOverlap = Math.Min(Math.Min(overlapLeft, overlapRight), Math.Min(overlapTop, overlapBottom));

        if (minOverlap == overlapTop)
        {
            // Collision from the top
            player.SetPositionY(blockRect.Top - playerRect.Height);
            player.SetVelocityY(0); // player stands on top of the obstacle
            player.SetIsOnGround(true);
            player.JumpStop();
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom (player jumps into the obstacle)
            player.SetPositionY(blockRect.Bottom);
            player.SetVelocityY(0); // Prevent player from going higher

            block.bump();
            if (!player.getStateMachine().IsSmall())
            {
                block.broke();
            }
            
            


        }
        else if (minOverlap == overlapLeft)
        {
            // Collision from the left
            player.SetPositionX(blockRect.Left - playerRect.Width);
            player.SetVelocityX(0); // Stop horizontal movement
        }
        else if (minOverlap == overlapRight)
        {
            // Collision from the right
            player.SetPositionX(blockRect.Right);
            player.SetVelocityX(0); // Stop horizontal movement
        }
    }

    private void StopPlayerHorizontalMovement()
    {
        player.SetVelocityX(0);
    }

    private void StopPlayerVerticalMovement()
    {
        // Set player's vertical velocity to 0
        player.SetVelocityY(0);
    }
}