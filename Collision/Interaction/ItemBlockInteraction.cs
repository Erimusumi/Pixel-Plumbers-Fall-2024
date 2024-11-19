using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemBlockInteraction
{
    private IItem item;
    private IBlock block;
    private Rectangle itemRect;
    private Rectangle blockRect;
    public ItemBlockInteraction(IItem i, IBlock block)
    {
        this.item = i;
        this.block = block;
        itemRect = item.GetDestination();
        blockRect = block.GetDestination();
    }
    public void update()
    {
        bool collision = itemRect.Intersects(blockRect);

        if (collision)
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

                item.setGroundPosition(blockRect.Y - 31);

                System.Diagnostics.Debug.Write("NotFalling is executed");
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
        }
        else
        {
            item.MakeFalling();
        }
    }
}
