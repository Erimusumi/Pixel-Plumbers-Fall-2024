using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MushroomInteraction
{
     private Mario mario;
    private MushroomObject mushroom;
    /* 
     * if(mario is small){
     * mario is big
     * change mario's current state to big mario
     * }
     * 
     */
    public MushroomInteraction(Mario mar, MushroomObject mush)
    {
        this.mario = mar;
        this.mushroom = mush;
    }

    public void update()
    {
        mushroom.collectedState();
       
    }


}

