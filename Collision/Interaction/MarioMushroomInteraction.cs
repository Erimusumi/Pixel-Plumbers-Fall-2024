using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class MarioMushroomInteraction
{
    private Mario mario;
    private Mushroom mushroom;
    private List<IEntity> entitiesRemoved;
    int mushroomIndex;
    int marioIndex;
    
    public MarioMushroomInteraction(Mario mar, Mushroom mush, List<IEntity> entitiesRemoved)
    {
        mario = mar;
        mushroom = mush;
        this.entitiesRemoved = entitiesRemoved;
    }

    public void update()
    {
     
        mushroom.collect();


        if (mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Small)
        {
            mario.MarioPowerUp();
        }

        removeFromList();
        
        
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(mushroom);


    }

}
    


