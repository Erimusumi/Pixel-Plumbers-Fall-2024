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
        item.swapDirection();
    }

  
    
}
