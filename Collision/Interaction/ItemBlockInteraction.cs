using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemBlockInteraction
{
    private IItem item;
    private IBlock block;
    private Rectangle itemRectangle;
    private Rectangle blockRect;
    public ItemBlockInteraction(IItem i, IBlock block)
    {
        this.item = i;
        this.block = block;
    }
    public void update()
    {
        Rectangle itemRect = item.GetDestination();
        Rectangle blockRect = block.GetDestination();
        // Calculate overlaps for each side
        int overlapTop = itemRect.Bottom - blockRect.Top;
        int overlapBottom = blockRect.Bottom - itemRect.Top;
        int overlapLeft = itemRect.Right - blockRect.Left;
        int overlapRight = blockRect.Right - itemRect.Left;

        // Find the smallest overlap to determine the side of collision
        int minOverlap = Math.Min(Math.Min(overlapTop, overlapBottom), Math.Min(overlapLeft, overlapRight));

        if (minOverlap == overlapTop)
        {
            // Collision from the top of the block

            item.NotFalling();
            System.Diagnostics.Debug.Write("NotFalling is executed");
        }
        else if (minOverlap == overlapBottom)
        {
            // Collision from the bottom of the block
            item.MakeFalling();
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
}
