using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

public class ItemBlockInteraction
{
    private IItem item;
    private IBlock block;
    private Rectangle itemRect;
    private Rectangle blockRect;
    private bool wasOnTop;
    private GameTime gameTime;
    public ItemBlockInteraction(IItem i, IBlock block, GameTime gameTime)
    {
        this.item = i;
        this.block = block;
        this.gameTime = gameTime;
        itemRect = item.GetDestination();
        blockRect = block.GetDestination();
        wasOnTop = false;
    }
    public void update()
    {
            // Calculate overlaps for each side
            int overlapTop = itemRect.Bottom - blockRect.Top;
            int overlapBottom = blockRect.Bottom - itemRect.Top;
            int overlapLeft = itemRect.Right - blockRect.Left;
            int overlapRight = blockRect.Right - itemRect.Left;

            // Find the smallest overlap to determine the side of collision
            float minOverlap = Math.Min(Math.Min(overlapLeft, overlapRight), Math.Min(overlapTop, overlapBottom));

            if (minOverlap == overlapTop)
            {
                // Collision from the top of the block

                item.SetPositionY(blockRect.Top - itemRect.Height);
                item.SetVelocityY(0); // player stands on top of the obstacle
                item.NotFalling();
                wasOnTop = true; // Mario is on the obstacle

                //System.Diagnostics.Debug.Write("NotFalling is executed");
            }
            else if (minOverlap == overlapLeft)
            {
                // Collision from the left side of the block
                item.swapDirection();
            }
            else if (minOverlap == overlapRight)
            {
                // Collision from the right side of the block
                item.swapDirection();

            }
        

        if (!itemRect.Intersects(blockRect))
        {
            // Mario is no longer colliding with the obstacle from the top
            if (wasOnTop)
            {
                item.SetIsOnGround(false); // Mario is no longer on the obstacle
                wasOnTop = false;
            }
        }

        // If Mario is not on the obstacle, apply gravity
        if (!item.GetIsOnGround())
        {
            item.ApplyGravity(gameTime); // Use the stored GameTime reference
        }
    }
}
