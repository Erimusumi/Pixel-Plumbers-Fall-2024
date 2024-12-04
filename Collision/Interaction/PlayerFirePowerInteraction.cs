﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class PlayerFirePowerInteraction
{
    private IPlayer player;
    private Fire FirePower;
    private List<IEntity> entitiesRemoved;


    public PlayerFirePowerInteraction(IPlayer play, Fire fp, List<IEntity> entitiesRemoved)
    {
        FirePower = fp;
        player = play;
        this.entitiesRemoved = entitiesRemoved;
    }
    public void update()
    {
        FirePower.collect();
        player.PowerUp();
        if (player.isFire())
        {
            player.PowerUp();
        }
        player.AddScore(100);
    }
    private void removeFromList()
    {
        //entitiesRemoved.Add(FirePower);
    }
}

