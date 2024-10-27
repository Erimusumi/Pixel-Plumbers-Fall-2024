using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class GroundTile
{
    private Texture2D ItemTexture;
    private int width;
        private int  height;
   

    public GroundTile(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
      
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0); //TODO: Get source rectangle

        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);

    }

    public void Update(GameTime gametime)
    {
    }
    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, width, height);
    }
}


