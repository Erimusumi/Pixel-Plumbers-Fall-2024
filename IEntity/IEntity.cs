using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IEntity
{
    void Update(GameTime gameTime);

    void Draw(SpriteBatch sb);

    public Rectangle GetDestinationRectangle();
}
