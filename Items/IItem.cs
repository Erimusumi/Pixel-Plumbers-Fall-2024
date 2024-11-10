using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem: IEntity
{
    public void swapDirection();
    public void update(GameTime gameTime);
    public void draw();
    public void destroy();
    public void roams();
    public void collect();
    public void idling();
    public void MakeFalling();
    public void NotFalling();


}

