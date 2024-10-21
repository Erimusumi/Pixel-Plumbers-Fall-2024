using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ItemObstacle
{
    private IItem item;
    private IObstacle obstacle;
    private Rectangle itemRectangle;
    private Rectangle obstacleRect;
    public ItemObstacle(List<IEntity> entities,int index, IObstacle obstacle)
    {
        this.item = (IItem) entities[index];
        this.obstacle = obstacle;
        itemRectangle = item.GetDestination();
        obstacleRect = obstacle.GetDestination();
    }

  
    
}
