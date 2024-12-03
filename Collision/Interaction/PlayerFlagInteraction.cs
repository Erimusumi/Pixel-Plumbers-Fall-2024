using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class PlayerFlagInteraction
{

    private IPlayer player;
    private Flag flag;
    private List<IEntity> entitiesRemoved;


    public PlayerFlagInteraction(IPlayer play, Flag flag, List<IEntity> entitiesRemoved)
    {
        this.flag = flag;
        this.player = play;
        this.entitiesRemoved = entitiesRemoved;
    }
    public void update()
    {
        Rectangle destination = player.GetDestination();
        flag.makeWinFlag(destination.Y);
        player.SetWin();
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(flag);
    }
}

