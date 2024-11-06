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

    public ToggleFalling(List<Rectangle> emptyGround, List<IEntity> objects)
    {
        this.emptyGround = emptyGround;
        this.objects = objects;
       
    }

    public void updateEntities()
    {
 for (int i = 0; i < objects.Count; i++)
        {
            for (int j = 0; j < emptyGround.Count; j++) {
                if (objects[i].GetDestination().Intersects(emptyGround[j]))
                {
                    //objects[i].isFalling();
                }
            }

        }
    }

    public void testMario(IEntity mar)
    {
        if (mar.GetDestination().Intersects(emptyGround[0]))
        {

        }
    }

}

