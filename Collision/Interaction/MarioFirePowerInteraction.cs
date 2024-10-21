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
    private List<IEntity> entitiesRemoved;


    public MarioFirePowerInteraction(Mario mar, Fire fp, List<IEntity> entitiesRemoved)
    {
        FirePower = fp;
        mario = mar;
        this.entitiesRemoved = entitiesRemoved;
    }
    public void update()
    {
        FirePower.collect();
        mario.MarioPowerUp();  
    }
    private void removeFromList()
    {
        entitiesRemoved.Add(FirePower);
    }
}

