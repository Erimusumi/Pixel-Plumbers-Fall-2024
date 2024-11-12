using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


    public class ToggleFalling
{
    private List<Rectangle> emptyGround;
    private List<IEntity> objects;
    private Ground ground;
    private float fallingGroundPosition = 480f;

    public ToggleFalling(Ground g, List<IEntity> objects)
    {
        this.ground = g;
        this.emptyGround = g.emptyGroundList();
        this.objects = objects;
       
    }

    public void updateEnemyFalling(IEnem)
    {
 for (int i = 0; i < objects.Count; i++)
        {
            for (int j = 0; j < ground.emptyGroundList().Count; j++) {
                if (objects[i].GetDestination().Intersects(emptyGround[j]))
                {
                    //objects[i].isFalling();
                }
            }

        }
    }
    public void updateItemFalling()
    {


    }
    
    public void updateMarioFalling(Mario mar)
    {
        if(ground.emptyGroundList().Count > 0)
        for(int i = 0; i < emptyGround.Count; i++)
        {
                if (mar.GetDestination().Intersects(emptyGround[i]))
            {
                mar.updateGroundPosition(480f);
            }
        }      
       
    }

}

