using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class MushroomInteraction
{
     private Mario mario;
     private MushroomObject mushroom;
    
    public MushroomInteraction(Mario mar, MushroomObject mush)
    {
        this.mario = mar;
        this.mushroom = mush;
    }

    public void update()
    {
        mushroom.roaming = false;
        mushroom.idle = false;
        mushroom.collected = true;

      /*  if (mario.isSmall)
        {
             change mario to big mario 
        }
      */
    }


}

