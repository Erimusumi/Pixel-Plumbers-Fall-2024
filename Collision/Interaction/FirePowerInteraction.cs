using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class FirePowerInteraction
{
    private Mario mario;
    private firePower FirePower;


    public FirePowerInteraction(Mario mar, firePower fp)
    {
        this.FirePower = fp;
        this.mario = mar;
       
    }
    public void update()
    {
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

