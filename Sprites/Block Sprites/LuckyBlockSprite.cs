using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
public class LuckyBlockSprite: IBlock
{
    public Texture2D Texture { get; set; }
    public Vector2 Start { get; set; }
    public Vector2 End { get; set; }
    public int numOfFrames { get; set; }
    public int waitTime { get; set; }
    private int buffer;
    public int width;
    public int height;
    private int currentFrame;
    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private Vector2 position;
    private Mushroom m;
    private int frames = 3;
    private int wait = 20;
    public Boolean bump = false;
    private Game1 game;
    private Texture2D itemTexture;
    private bool hasMushroomAppeared;
    SpriteBatch spriteBatch;
    private Vector2 velocity;
    private float gravity = 980f;
    private Vector2 m_position;
    public LuckyBlockSprite(Texture2D texture, SpriteBatch spriteBatch, Texture2D itemTexture, Game1 game)
    {
        Texture = texture;
        Start = new Vector2(80, 112);
        End = new Vector2(128, 128);
        buffer = 0;                 // counts up until timeGap to indicate when to change frames
        currentFrame = 0;
        width = (int)(End.X - Start.X) / frames;
        height = (int)(End.Y - Start.Y);
        this.game = game;
        this.itemTexture = itemTexture;
        this.spriteBatch = spriteBatch;
        this.velocity = Vector2.Zero;
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

        if (bump && !hasMushroomAppeared)
        {
            m_position = new Vector2(position.X, position.Y - 31);
            m = new Mushroom(spriteBatch, itemTexture);
            game.entities.Add(m);

            hasMushroomAppeared = true; // Set the flag to prevent drawing again
        }

        if (bump)
        {
            m.update(gametime);
            velocity.Y += gravity * (float)gametime.ElapsedGameTime.TotalSeconds;
            m_position += velocity * (float)gametime.ElapsedGameTime.TotalSeconds; // Update position


        }
    }
    public void Draw(SpriteBatch spriteBatch2, Vector2 position)
    {
        this.position = position;
        //sourceRectangle = new Rectangle((int)Start.X + width * (numOfFrames - currentFrame - 1), (int)Start.Y,
        //        width, height);
        sourceRectangle = new Rectangle(80, 112, 16, 16);
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);

        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        if (hasMushroomAppeared && m != null)
        {
            m.draw(m_position); // Draw the mushroom consistently once it appears
        }


    }
    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }
    public void Load(GraphicsDeviceManager graphics)
    {

    }
}
