using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace cse3902
{
    public class OneFrameSprite: ISprite
    {
        public Texture2D texture { get; set; }
        public OneFrameSprite(Texture2D texture) {
       
            this.texture = texture;
        }
        public void Update()
        {
            // non-animated, non-moving no updates required to the sprite
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(174, 48, 27, 38);
            spriteBatch.Begin();
            spriteBatch.Draw(
                    texture,
                    location,
                    sourceRectangle,
                    Color.White,
                    0f,
                    new Vector2(texture.Width / 2, texture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
            );
            spriteBatch.End();
        }
    }
}
