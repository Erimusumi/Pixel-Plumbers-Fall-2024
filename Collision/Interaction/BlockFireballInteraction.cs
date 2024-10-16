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
    private Fireball fireball;
    private UnknownBlockSprite block;


    public BlockFireballInteraction(Fireball _fireball, UnknownBlockSprite _block)
    {
        this.block = _block;
        this.fireball = _fireball;
       
    }
    public void update()
    {
        //Check if overlap in rectangles has more horizontal area than vertical area
        //This means collision type is a top/bottom
        Rectangle temp = Rectangle.Intersect(block.GetDestination(), fireball.GetDestination());
        if (temp.Width > temp.Height)
        {
            //Check if fireball is on top or bottom
            if (fireball.GetDestination().Center.Y > block.GetDestination().Center.Y)
            {
                fireball.Bounce();
            }
        }
        else
        {
            //Delete fireball
        }
    }
    private void removeFromList()
    {
        //remove fireball from list of entities
    }
}

