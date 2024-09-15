using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace cse3902
{
    public class TextSprite: ISprite
    {
        private SpriteFont font;
        private String text;

        public TextSprite(SpriteFont font, String text) 
        {  
            this.font = font;
            this.text = text;
        }

        public void Update()
        {
            // non-moving, non-animated no updates to font needed
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, position, Color.Black);
            spriteBatch.End();
        }

    }
}
