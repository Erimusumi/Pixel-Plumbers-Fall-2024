using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace sprint_0
{
    public class OneFrameSprite
    {
        public Texture2D texture { get; set; }
        public Rectangle rectangle {get; set; }
        public OneFrameSprite(Texture2D texture, Rectangle rectangle) {
       
            this.texture = texture;
            this.rectangle = rectangle;
        }
        public void Update()
        {
            // non-animated, non-moving no updates required to the sprite
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, rectangle, Color.White);
            spriteBatch.End();
        }
    }
}