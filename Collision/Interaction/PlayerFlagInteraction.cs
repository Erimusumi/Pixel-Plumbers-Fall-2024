using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    DisablePlayerCommand disablePlayerCommand;

    public PlayerFlagInteraction(IPlayer play, Flag flag, List<IEntity> entitiesRemoved, DisablePlayerCommand disablePlayerCommand)
    {
        this.flag = flag;
        this.player = play;
        this.entitiesRemoved = entitiesRemoved;
        this.disablePlayerCommand = disablePlayerCommand;
    }

    public void update()
    {
        disablePlayerCommand.Execute();
        Rectangle destination = player.GetDestination();
       // flag.makeWinFlag(destination.Y);
        //flag.resetFlag();
        
       //player.SetWin();
        
        WinCutScene wc = new WinCutScene(player, destination);
        wc.play();
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(flag);
    }
}

