using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class EnemyFireballInteraction
{
    private Fireball fireball;
    private ISpriteEnemy enemy;


    public EnemyFireballInteraction(Fireball _fireball, ISpriteEnemy _enemy)
    {
        this.enemy = _enemy;
        this.fireball = _fireball;
       
    }
    public void update()
    {
        enemy.beFlipped();
        fireball.Remove();
    }
    private void removeFromList()
    {
        //remove fireball from list of entities
        //should enemy be removed here too?
    }
}

