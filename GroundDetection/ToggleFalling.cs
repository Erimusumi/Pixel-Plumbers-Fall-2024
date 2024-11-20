using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


    public class ToggleFalling
{
    private List<Rectangle> collisionRects;
    private List<IEntity> entities;
    private List<IEntity> enemies;
    private List<IItem> items;
    private Mario mario;
    private Ground ground;
    private float fallingGroundPosition = 480f;
    
    FilterEntities filterEntities;
    Boolean marioIsColliding = true;
    Boolean emptyCollision = false;
    int hitCount= 0;
   

    public ToggleFalling(Ground g, List<IEntity> entities, Mario mario)
    {
        this.ground = g;
        this.collisionRects = g.allCollisionRectangles();
        this.entities = entities;
        filterEntities = new FilterEntities();
       enemies = filterEntities.FilterEnemies(entities);
       
    }
  

    public void updates()
    {
        updateMarioFalling(this.mario);
        updateItemFalling(items);

    }

    public void updateEnemyFalling()
    {
        

        for (int i = 0; i < enemies.Count; i++)
        {
            {
                for (int j = 0; j < collisionRects.Count; j++)
                {
                    if (enemies[i].GetDestination().Intersects(collisionRects[j]))
                    {
                       
                    }
                }

            }
        }
    }
    public void updateItemFalling(List<IItem> items)
    {
        Boolean intersects = true;
      
        for (int i = 0; i < items.Count; i++)
        {
            {
                for (int j = 0; j < collisionRects.Count; j++)
                {
                    if (items[i].GetDestination().Intersects(collisionRects[j]))
                    {
                        items[i].setGroundPosition(480);
                    }
                }

            }
        }

    }

    public void updateMarioFalling(Mario mar)
    {
        
        for (int i = 0; i < collisionRects.Count; i++)
        {
            if(mar.GetDestination().Intersects(collisionRects[i]))
               {
                if (mar.isSmall())
                {
                    mar.updateGroundPosition(385f);
                }
                else
                {
                    mar.updateGroundPosition(385f -32);
                }
                
                marioIsColliding = true;
                hitCount++;

                break;
            }
           
        }
        if(hitCount == 0)
        {
            marioIsColliding = false;
        }
        if (!marioIsColliding && mar.GetDestination().Intersects(new Rectangle(mar.GetDestination().X, (int)mar.GroundPosition(), 16, 16)))
        {

            mar.updateGroundPosition(480f);
        }
        hitCount = 0;       
    }

}

