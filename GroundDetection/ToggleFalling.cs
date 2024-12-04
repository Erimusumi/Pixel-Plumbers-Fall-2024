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
        for (int i = 0; i < fireBalls.Count; i++)
        {
            Fireball fireBall = (Fireball)fireBalls[i];
            Rectangle fireBallBounds = fireBall.GetDestination();
            bool fireBallColliding = false;
            for (int j = 0; j < collisionRects.Count; j++)
            {
                Rectangle blockBounds = collisionRects[j];
                if (fireBallBounds.Intersects(blockBounds))
                {
                    fireBallColliding = true;
                    if (fireBallBounds.Bottom > blockBounds.Top &&
                        fireBallBounds.Top < blockBounds.Top &&
                        fireBallBounds.Right > blockBounds.Left &&
                        fireBallBounds.Left < blockBounds.Right)
                    {
                        fireBall.Bounce();
                    }
                    else if (fireBallBounds.Right > blockBounds.Left &&
                             fireBallBounds.Left < blockBounds.Left)
                    {
                        fireBall.Remove();
                    }
                    else if (fireBallBounds.Left < blockBounds.Right &&
                             fireBallBounds.Right > blockBounds.Right)
                    {
                        fireBall.Remove();
                    }
                    break;
                }
            }
            if (!fireBallColliding)
            {
                // I guess it would just keep its velocity until collision again.
            }
        }
    }



    public void updateEnemyFalling(List<IEntity> enemies)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            ISpriteEnemy currentEnemy = (ISpriteEnemy)enemies[i];
            Rectangle enemyBounds = currentEnemy.GetDestination();
            bool enemyColliding = false;
            for (int j = 0; j < collisionRects.Count; j++)
            {
                Rectangle blockBounds = collisionRects[j];
                if (enemyBounds.Intersects(blockBounds))
                {
                    
                    enemyColliding = true;
                    if (enemyBounds.Bottom > blockBounds.Top &&
                        enemyBounds.Top < blockBounds.Top &&
                        enemyBounds.Right > blockBounds.Left &&
                        enemyBounds.Left < blockBounds.Right)
                    {
                        currentEnemy.setGroundPosition(blockBounds.Top);
                       
                    }
                    else if (enemyBounds.Right > blockBounds.Left &&
                             enemyBounds.Left < blockBounds.Left)
                    {
                        currentEnemy.changeDirection();
                    }
                    else if (enemyBounds.Left < blockBounds.Right &&
                             enemyBounds.Right > blockBounds.Right)
                    {
                        currentEnemy.changeDirection();
                    }

                    break;
                }
            }
            if (!enemyColliding)
            {
                // Make it fall when that functionality is added.
                currentEnemy.setGroundPosition(fallingGroundPosition); //set to fall below screen
            }
        }
    }


    public void updateItemFalling(List<IEntity> items)
    {
        for (int j = 0; j < items.Count; j++)
        {
            IItem item = (IItem)items[j];
            Rectangle itemBounds = item.GetDestination();
            bool itemColliding = false;
            for (int i = 0; i < collisionRects.Count; i++)
            {
                Rectangle blockBounds = collisionRects[i];
                if (itemBounds.Intersects(blockBounds))
                {
                    itemColliding = true;
                    if (itemBounds.Bottom > blockBounds.Top &&
                        itemBounds.Top < blockBounds.Top &&
                        itemBounds.Right > blockBounds.Left &&
                        itemBounds.Left < blockBounds.Right)
                    {
                        item.setGroundPosition(blockBounds.Top - 32);
                    }
                    else if (itemBounds.Right > blockBounds.Left &&
                             itemBounds.Left < blockBounds.Left)
                    {
                        item.swapDirection();
                    }
                    else if (itemBounds.Left < blockBounds.Right &&
                             itemBounds.Right > blockBounds.Right)
                    {
                        item.swapDirection();
                    }
                    break;
                }
            }

            if (!itemColliding)
            {
                if (itemBounds.Intersects(new Rectangle(itemBounds.X, 385, 16, 16)))
                {
                    item.setGroundPosition(480);
                }
            }
        }
    }



    public void updateMarioFalling(Mario mar)
    {
        PlayerStateMachine playerStateMachine = mario.getStateMachine();
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
                    if (playerStateMachine.IsSmall())
                    {
                        mar.updateGroundPosition(groundPosition - 32);
                    }
                    else
                    {
                        if (playerStateMachine.IsCrouching())
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
        PlayerStateMachine playerStateMachine = luigi.getStateMachine();
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

                    if (playerStateMachine.IsSmall())
                    {
                        lui.updateGroundPosition(groundPosition - 32);
                    }
                    else
                    {
                        if (playerStateMachine.IsCrouching())
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