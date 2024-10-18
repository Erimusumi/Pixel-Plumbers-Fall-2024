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
    private List<IEntity> _entities;


    public EnemyFireballInteraction(Fireball _fireball, ISpriteEnemy _enemy, List<IEntity> entities)
    {
        this.enemy = _enemy;
        this.fireball = _fireball;
        this._entities = entities;
    }
    public void update()
    {
        enemy.beFlipped();
        fireball.Remove();
        removeFromList();
    }
    private void removeFromList()
    {
        _entities.Remove(enemy);
        _entities.Remove(fireball);
    }
}

