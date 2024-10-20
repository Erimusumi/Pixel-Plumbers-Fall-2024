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
        item.collect();
        /*if (item.GetType() == typeof(Mushroom) && mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Small)
        {
            mario.MarioPowerUp();
        }
        if (item.GetType() == typeof(FirePower) && mario.GetMarioGameState() == MarioStateMachine.MarioGameState.Big)
        {
            mario.MarioPowerUp();
        }
        */
        mario.MarioPowerUp();
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(item);
    }
}
