using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MarioGroundInteraction
{
 private Mario mario;
private Ground ground;
private List<IEntity> entities;


    public MarioGroundInteraction(Mario mar, Ground g, List<IEntity> entities)
    {
        this.mario = mar;
        this.ground = g;
        this.entities = entities;
    }
public void update()
{
        mario.marioVelocity.Y = 0;
}
}

