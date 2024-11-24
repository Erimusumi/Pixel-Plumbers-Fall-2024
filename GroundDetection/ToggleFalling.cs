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
    private List<IEntity> items;
    private Mario mario;
    private Ground ground;
    private float fallingGroundPosition = 480f;

    FilterEntities filterEntities;
    Boolean marioIsColliding = true;
    Boolean emptyCollision = false;
    int marHitCount = 0;
    int itemHitCount = 0;


    public ToggleFalling(Ground g, List<IEntity> entities, Mario mario)
    {
        this.ground = g;
        this.collisionRects = g.allCollisionRectangles();
        this.entities = entities;
        filterEntities = new FilterEntities();
        enemies = filterEntities.FilterEnemies(entities);
        items = filterEntities.FilterItems(entities);
        this.mario = mario;

    }


    public void updates()
    {
        updateMarioFalling(this.mario);
        updateItemFalling(items);

    }

    public void updateEnemyFalling()
    {
        
        ISpriteEnemy currentEnemy;
        for (int i = 0; i < enemies.Count; i++)
        {
            //Boolean enemyColliding = true;
            currentEnemy = (ISpriteEnemy)enemies[i];        
           
            {
                for (int j = 0; j < collisionRects.Count; j++)
                {
                    if (!currentEnemy.GetDestination().Intersects(collisionRects[j]) && currentEnemy.GetDestination().Intersects(new Rectangle(currentEnemy.GetDestination().X, 385, 16, 16)))
                    {
                        currentEnemy.setGroundPosition(480);
                    }
                }

            }
        }
    }
    public void updateItemFalling(List<IEntity> item)
    {
        // Boolean itemColliding = true;


        for (int i = 0; i < items.Count; i++)
        {
            IItem x = (IItem)item[i];
            {
                for (int j = 0; j < collisionRects.Count; j++)
                {
                    if (!x.GetDestination().Intersects(collisionRects[j]) && x.GetDestination().Intersects(new Rectangle(x.GetDestination().X, 380, 16, 16)))
                    {
                        x.setGroundPosition(480);
                    }
                }

            }
        }
    }

    public void updateMarioFalling(Mario mar)
    {

        for (int i = 0; i < collisionRects.Count; i++)
        {
            if (mar.GetDestination().Intersects(collisionRects[i]))
            {
                if (mar.isSmall())
                {
                    mar.updateGroundPosition(385f);
                }
                else
                {
                    mar.updateGroundPosition(385f - 32);
                }

                marioIsColliding = true;
                marHitCount++;

                break;
            }

        }
        if (marHitCount == 0)
        {
            marioIsColliding = false;
        }
        if (!marioIsColliding && mar.GetDestination().Intersects(new Rectangle(mar.GetDestination().X, (int)mar.GroundPosition(), 16, 16)))
        {

            mar.updateGroundPosition(480f);
        }
        marHitCount = 0;
    }

}

