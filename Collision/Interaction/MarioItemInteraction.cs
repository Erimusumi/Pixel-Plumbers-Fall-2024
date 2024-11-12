using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public class MarioItemInteraction
{
    private Mario mario;
    private IItem item;
    private List<IEntity> entitiesRemoved;
    public MarioItemInteraction(IItem item, Mario mario, List<IEntity> entitiesRemoved)
	{
        this.item = item;
        this.mario = mario;
        this.entitiesRemoved = entitiesRemoved;
    }
    public void update()
    {
        //item.collect();
        if (mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Small)
        {
            mario.MarioPowerUp();
        }
        else if (mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Big)
        {
            mario.MarioPowerUp();
        }
        else if (mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Fire)
        {
            mario.MarioPowerUp();
        }
        removeFromList();
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(item);
    }
}
