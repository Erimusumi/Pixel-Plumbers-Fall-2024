﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class LuckyBlockSprite: ISprite
{
    public Texture2D Texture { get; set; }
    public Vector2 Start { get; set; }
    public Vector2 End { get; set; }
    public int numOfFrames { get; set; }
    public int waitTime { get; set; }
    private int buffer;
    private int width;
    private int height;
    private int currentFrame;
    public LuckyBlockSprite(Texture2D texture, Vector2 start, Vector2 end, int frames, int wait)
    {
        Texture = texture;
        Start = start;
        End = end;
        numOfFrames = frames;
        waitTime = wait;            // the amount of time between frame changes
        buffer = 0;                 // counts up until timeGap to indicate when to change frames
        currentFrame = 0;
        width = (int)(End.X - Start.X) / frames;
        height = (int)(End.Y - Start.Y);
    }
    
    public void Update(GameTime gametime)
    {
        buffer++;
        if (buffer == waitTime)
        {
            buffer = 0;                     // restarts buffer to start waiting again
            currentFrame++;
            if (currentFrame == numOfFrames)
            {
                currentFrame = 0;           // restarts the animation from the first frame
            }
        }
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle((int)Start.X + width * (numOfFrames - currentFrame - 1), (int)Start.Y,
                width, height);
        Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
    public void Load(GraphicsDeviceManager graphics)
    {

    }
}