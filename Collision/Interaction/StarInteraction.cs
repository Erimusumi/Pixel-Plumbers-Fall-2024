using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StarInteraction
{
    private Mario mario;
    private firePower FirePower;


    public StarInteraction(Mario mar, firePower fp)
    {
        this.FirePower = fp;
        this.mario = mar;

    }
    public void update()
    {
        Star
        FirePower.collected = true;
        FirePower.idle = false;
        FirePower.roaming = false;

        mario.MarioPowerUp();
    }
    private void removeFromList()
    {
        //remove fire power from list of entities
    }
}
