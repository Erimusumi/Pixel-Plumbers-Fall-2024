using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MarioStarInteraction
{
    private Mario mario;
    private Star star;
    private List<IEntity> entitiesRemoved;
    int count = 0;


    public MarioStarInteraction(Mario mar, Star s, List<IEntity> entitiesRemoved)
    {
        this.star = s;
        this.mario = mar;
        this.entitiesRemoved = entitiesRemoved;

    }
    public void update()
    {
      
        star.collect();
        mario.CollectStar();
        removeFromList();
         
        
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(star);
    }
}
