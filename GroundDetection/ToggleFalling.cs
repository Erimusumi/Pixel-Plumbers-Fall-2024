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
    private List<IEntity> objects;
    private Ground ground;
    private float fallingGroundPosition = 480f;
    Boolean marioIsColliding = true;
   

    public ToggleFalling(Ground g, List<IEntity> objects)
    {
        this.ground = g;
        this.collisionRects = g.allCollisionRectangles();
        this.objects = objects;
       
    }

    public void updateEnemyFalling(List<ISpriteEnemy> enemies)
    {

        for (int i = 0; i < enemies.Count; i++)
        {
            {
                for (int j = 0; j < collisionRects.Count; j++)
                {
                    if (enemies[i].GetDestination().Intersects(collisionRects[j]))
                    {
                        enemies[i].setGroundPosition(480f);
                    }
                }

            }
        }
    }
    public void updateItemFalling(List<IItem> items)
    {
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
       for(int i = 0; i < collisionRects.Count; i++)
        {

            
            if (mar.GetDestination().Intersects(collisionRects[i]))
            {
                mar.updateGroundPosition(385f);
                marioIsColliding = true;
                break;
                
            }if (!mar.GetDestination().Intersects(collisionRects[i]) && mar.GetDestination().Intersects(new Rectangle(mar.GetDestination().X, (int)mar.GroundPosition(),16,16) ))
            {

                if (!marioIsColliding)
                {
                    mar.updateGroundPosition(480f);
                }
                
                marioIsColliding = false;
                
            }
        }   
       
       
    }

}

