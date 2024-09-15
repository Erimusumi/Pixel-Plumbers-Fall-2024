using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace cse3902
{
    public class MovingAnimatedSprite: ISprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Start { get; set; }
        public Vector2 End { get; set; }
        public int numOfFrames { get; set; }
        public int timeGap { get; set; }
        private int buffer;
        private int width;
        private int height;
        private int currentFrame;
        private int PositionX;
        public MovingAnimatedSprite(Texture2D texture, Vector2 start, Vector2 end, Vector2 position, int frames, int gap)
        {
            Texture = texture;
            Start = start;
            End = end;
            numOfFrames = frames;       
            timeGap = gap;              // the amount of time between frame changes
            buffer = 0;                 // counts up until timeGap to indicate when to change frames
            currentFrame = 0;           
            width = (int)(End.X - Start.X) / frames;            
            height = (int)(End.Y - Start.Y);                    
            PositionX = (int)position.X;                        
        }
        public void Update()
        {
            buffer++;
            if (buffer == timeGap)
            {
                buffer = 0;
                currentFrame++;
                if (currentFrame == numOfFrames)
                {
                    currentFrame = 0;           // restarts the animation from the first frame
                }
            }

            if (PositionX + 1 <= 800)
            {
                PositionX++;
            }
            else
            {
                PositionX = 0;                  // restarts sprite once it hits end of screen
            }


        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle((int)Start.X + width * (numOfFrames - currentFrame - 1), (int)Start.Y,
                width, height);
            Rectangle destinationRectangle = new Rectangle(PositionX, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
