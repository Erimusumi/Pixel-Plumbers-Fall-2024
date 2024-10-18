using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class MarioFirePowerInteraction
{
    private Mario mario;
    private Fire FirePower;


    public MarioFirePowerInteraction(Mario mar, Fire fp)
    {
        FirePower = fp;
        mario = mar;
       
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

