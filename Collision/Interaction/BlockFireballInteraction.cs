using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

    public class BlockFireballInteraction
{
    private Fireball _fireball;
    private UnknownBlockSprite _block;
    private List<IEntity> _entities;

    public BlockFireballInteraction(Fireball fireball, UnknownBlockSprite block, List<IEntity> entities)
    {
        this._block = block;
        this._fireball = fireball;
        this._entities = entities;
    }
    public void update()
    {
        //Check if overlap in rectangles has more horizontal area than vertical area
        //This means collision type is a top/bottom
        Rectangle temp = Rectangle.Intersect(_block.GetDestination(), _fireball.GetDestination());
        if (temp.Width > temp.Height)
        {
            //Check if fireball is on top or bottom
            if (_fireball.GetDestination().Center.Y > _block.GetDestination().Center.Y)
            {
                _fireball.Bounce();
            }
        }
        else
        {
            _fireball.Remove();
            removeFromList();
        }
    }
    private void removeFromList()
    {
        _entities.Remove(_fireball);
    }
}

