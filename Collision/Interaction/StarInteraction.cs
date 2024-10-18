using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MarioStarInteraction
{
    private Mario mario;
    private Star star;
    int count = 0;


    public MarioStarInteraction(Mario mar, Star s)
    {
        this.star = s;
        this.mario = mar;


    }
    public void update()
    {
        if (count == 0)
        {
            star.collect();
            mario.CollectStar();
            count++;
        }
    }
    private void removeFromList(List<object> entit,int index)
    {
      //  entit.Remove(index);
    }
}
