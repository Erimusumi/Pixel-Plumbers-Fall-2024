using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MarioStarInteraction
{
    private Mario mario;
    private Star star;


    public MarioStarInteraction(Mario mar, Star s)
    {
        this.star = s;
        this.mario = mar;

    }
    public void update()
    {
        star.collected = true;
        star.roaming = false;
        star.idle = false;
        mario.CollectStar();
    }
    private void removeFromList(List<object> entit,int index)
    {
        entit.Remove(index);
    }
}
