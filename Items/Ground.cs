using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ground: IEntity
{
    private Vector2 position;
    private Texture2D texture;
    private SpriteBatch sB;
    private GroundTile g;
    public Ground(Vector2 pos, Texture2D texture, SpriteBatch sB)
    {
        g = new GroundTile(texture);
        this.position = pos;
        this.texture = texture;

    }
    public void draw()
    {
        g.Draw( sB, position);
    }
    public void Update()
    {

    }
    
   public Rectangle GetDestination()
    {
        return this.g.GetDestination(position);
    }

}

