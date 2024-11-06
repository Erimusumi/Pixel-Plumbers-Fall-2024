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
        this.objects = objects;
       
    }

    public void updateEntities()
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

    public void updateMarioFallingTest(Mario mar)
    {
        
 if (mar.GetDestination().Intersects(emptyGround[0]))
        {
                mar.updateGroundPosition(480f);
        }        
       
    }

}

