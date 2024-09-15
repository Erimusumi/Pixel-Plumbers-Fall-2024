using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace cse3902
{
    public class MovingOneFrameSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        private Vector2 Position;
        private int PositionY;
        public MovingOneFrameSprite(Texture2D texture, Vector2 position)
        {

            Texture = texture;
            Position = position;
            PositionY = (int)position.Y;
        }
        public void Update()
        {
            if (PositionY - 1 > 0)
            {
                PositionY--;
            }
            else
            {
                PositionY = 480;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 Position)
        {
            Rectangle sourceRectangle = new Rectangle(174, 48, 27, 38);
            Rectangle destinationRectangle = new Rectangle((int)Position.X, PositionY, 27, 38);
           
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
