using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemObstacleInteraction
{
    private IItem item;
    private IObstacle obstacle;
    private Rectangle itemRectangle;
    private Rectangle obstacleRect;
    public ItemObstacleInteraction(IItem i, IObstacle obstacle)
    {
        this.item = i;
        this.obstacle = obstacle;
      
    }
    public void update()
    {
        Rectangle o_rectangle = obstacle.GetDestination();
        Rectangle i_rectangle = item.GetDestination();

        // Calculate the intersection rectangle
        Rectangle intersection = Rectangle.Intersect(i_rectangle, o_rectangle);

        // Determine collision side in terms of obstacle
        if (intersection.Width < intersection.Height)
        {
            // Horizontal collision with obstacle (left or right)
            item.swapDirection();
        }
        else
        {
            // Vertical collision with obstacle (top or bottom)
            if (i_rectangle.Bottom <= o_rectangle.Top + intersection.Height)
            {
                // Collision on the top side of the obstacle
                item.NotFalling();
                System.Diagnostics.Debug.Write("item.notFalling is executed");
            }
            else
            {
                // Collision on the bottom side of the obstacle
                
            }
        }

        item.swapDirection();
    }

  
    
}
