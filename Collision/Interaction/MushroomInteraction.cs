using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class MushroomInteraction
{
    private Mario mario;
    private MushroomObject mushroom;
    int mushroomIndex;
    int marioIndex;
    
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

        if (mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Small)
        {
            mario.MarioPowerUp();
        }
        
    }
    private void removeFromList()
    {
        //remove mushroom from list of entities


    }

}
    


