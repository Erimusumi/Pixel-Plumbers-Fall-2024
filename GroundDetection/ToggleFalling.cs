using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Runtime.InteropServices;


public class ToggleFalling
{
    private List<Rectangle> collisionRects;
    private List<IEntity> entities;
    private List<IEntity> enemies;
    private List<IEntity> items;
    private List<IEntity> fireballs;
    private Mario mario;
    private Luigi luigi;
    private Ground ground;
    private float fallingGroundPosition = 480f;

    FilterEntities filterEntities;
    Boolean marioIsColliding = true;
    Boolean luigiIsColliding = true;
    Boolean emptyCollision = false;
    int marHitCount = 0;
    int luiHitCount = 0;
    int itemHitCount = 0;


    public ToggleFalling(Ground g, List<IEntity> entities, Mario mario, Luigi luigi)
    {
        this.ground = g;
        this.collisionRects = g.allCollisionRectangles();
        this.entities = entities;
        filterEntities = new FilterEntities();
        enemies = filterEntities.FilterEnemies(entities);
        items = filterEntities.FilterItems(entities);
        fireballs = filterEntities.FilterFireballs(entities);
        Debug.WriteLine("There are" + fireballs.Count + "fireballs");
        //Debug.WriteLine("There are " + items.Count + " items");
        this.mario = mario;
        this.luigi = luigi;
    }


    public void updates()
    {
        updateLuigiFalling(this.luigi);
        updateMarioFalling(this.mario);
        updateItemFalling(this.items);
        updateEnemyFalling(this.enemies);
        updateFireBallFalling(this.fireballs);
    }

    public void updateFireBallFalling(List<IEntity> fireBalls)
    {
        Fireball fireBall;
        
        
        for (int i = 0; i < fireBalls.Count; i++)
        {
            fireBall = (Fireball)fireBalls[i];
            for (int j = 0; j < collisionRects.Count; j++)
            {
                if (fireBall.GetDestination().Intersects(collisionRects[j]) && fireBall.GetDestination().Intersects(new Rectangle(fireBall.GetDestination().X, 400, 16, 16)))
                {
                    fireBall.Bounce();
                }
                //if (fireBall.GetDestination().Intersects(new Rectangle(collisionRects.X,collisionRects.Y)collisionRects[j].Left))
                //{

                //}else if (fireBall.GetDestination().Intersects())
                //{

                //}
            }
        }

    }


    public void updateEnemyFalling(List<IEntity> enemies)
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
        Boolean itemColliding = true;
        int hitCount = 0;

        for (int j = 0; j < items.Count; j++)
        {
            IItem x = (IItem)item[j];
            for (int i = 0; i < collisionRects.Count; i++)
            {
                if (x.GetDestination().Intersects(collisionRects[i]))
                {
                    x.setGroundPosition(385);
                    itemColliding = true;
                    hitCount++;

                    break;
                }
            }

            if (hitCount == 0)
            {
                itemColliding = false;
            }
            if (!itemColliding && x.GetDestination().Intersects(new Rectangle(x.GetDestination().X, 385, 16, 16)))
            {

                x.setGroundPosition(480);
            }
        }
        hitCount = 0;


    }

    public void updateMarioFalling(Mario mar)
    {

        Rectangle marioBounds = mar.GetDestination();
        for (int i = 0; i < collisionRects.Count; i++)
        {
            Rectangle blockBounds = collisionRects[i];

            if (marioBounds.Intersects(blockBounds))
            {
                marioIsColliding = true;
                marHitCount++;

                if (marioBounds.Bottom > blockBounds.Top &&
                    marioBounds.Top < blockBounds.Top &&
                    marioBounds.Right > blockBounds.Left &&
                    marioBounds.Left < blockBounds.Right)
                {
                    float groundPosition = blockBounds.Top;

                    if (mar.isSmall())
                    {
                        mar.updateGroundPosition(groundPosition - 32);
                    }
                    else
                    {
                        if (mar.IsCrouching())
                        {
                            mar.updateGroundPosition(groundPosition - 42);
                        }
                        else
                        {
                            mar.updateGroundPosition(groundPosition - 64);
                        }
                    }

                    break;
                }

                if (marioBounds.Right > blockBounds.Left &&
                    marioBounds.Left < blockBounds.Left &&
                    marioBounds.Bottom > blockBounds.Top &&
                    marioBounds.Top < blockBounds.Bottom)
                {
                    mar.Stop();
                    break;
                }

                if (marioBounds.Left < blockBounds.Right &&
                    marioBounds.Right > blockBounds.Right &&
                    marioBounds.Bottom > blockBounds.Top &&
                    marioBounds.Top < blockBounds.Bottom)
                {
                    mar.Stop();
                    break;
                }

            }
        }
        if (marHitCount == 0)
        {
            marioIsColliding = false;
        }
        if (!marioIsColliding && mar.GetDestination().Intersects(new Rectangle(mar.GetDestination().X, (int)mar.GroundPosition(), 16, 16)))
        {
            mar.updateGroundPosition(mar.GroundPosition() + 100f); // Mario falls by 5 units per frame
        }
        marHitCount = 0;
    }

    public void updateLuigiFalling(Luigi lui)
    {
        Rectangle luigiBounds = lui.GetDestination();
        for (int i = 0; i < collisionRects.Count; i++)
        {
            Rectangle blockBounds = collisionRects[i];
            if (luigiBounds.Intersects(blockBounds))
            {
                luigiIsColliding = true;
                luiHitCount++;

                if (luigiBounds.Bottom > blockBounds.Top &&
                    luigiBounds.Top < blockBounds.Top &&
                    luigiBounds.Right > blockBounds.Left &&
                    luigiBounds.Left < blockBounds.Right)
                {
                    float groundPosition = blockBounds.Top;

                    if (lui.isSmall())
                    {
                        lui.updateGroundPosition(groundPosition - 32);
                    }
                    else
                    {
                        if (lui.IsCrouching())
                        {
                            lui.updateGroundPosition(groundPosition - 42);
                        }
                        else
                        {
                            lui.updateGroundPosition(groundPosition - 64);
                        }
                    }
                    break;
                }

                if (luigiBounds.Right > blockBounds.Left &&
                    luigiBounds.Left < blockBounds.Left &&
                    luigiBounds.Bottom > blockBounds.Top &&
                    luigiBounds.Top < blockBounds.Bottom)
                {
                    lui.Stop();
                    break;
                }

                if (luigiBounds.Left < blockBounds.Right &&
                    luigiBounds.Right > blockBounds.Right &&
                    luigiBounds.Bottom > blockBounds.Top &&
                    luigiBounds.Top < blockBounds.Bottom)
                {
                    lui.Stop();
                    break;
                }
            }
        }

        if (luiHitCount == 0)
        {
            luigiIsColliding = false;
        }

        if (!luigiIsColliding && lui.GetDestination().Intersects(new Rectangle(lui.GetDestination().X, (int)lui.GroundPosition(), 16, 16)))
        {
            lui.updateGroundPosition(lui.GroundPosition() + 100f);
        }
        
        luiHitCount = 0;
    }
}

