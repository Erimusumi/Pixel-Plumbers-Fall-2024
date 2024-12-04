using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Pixel_Plumbers_Fall_2024;
using System;

public class LuckyBlockSprite : IBlock
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
    private IItem item;
    private Coin coin;
    private int frames = 3;
    private int wait = 20;
    public Boolean bumping = false;
    private Game1 game;
    private Mario mario;
    private Texture2D itemTexture;
    private bool hasItemAppeared;
    SpriteBatch spriteBatch;
    private Vector2 i_position;
    public LuckyBlockSprite(Texture2D texture, SpriteBatch spriteBatch, Texture2D itemTexture, Game1 game, Mario mario, Vector2 position)
    {
        Texture = texture;
        Start = new Vector2(80, 112);
        End = new Vector2(128, 128);
        buffer = 0;
        currentFrame = 0;
        // Set the animation properties
        numOfFrames = frames;  // Use the frames field
        waitTime = wait;       // Use the wait field
        width = (int)(End.X - Start.X) / frames;
        height = (int)(End.Y - Start.Y);
        this.game = game;
        this.itemTexture = itemTexture;
        this.spriteBatch = spriteBatch;
        this.mario = mario;
        this.position = position;
        destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 31, 31);
        
        
    }

    public void Update(GameTime gametime)
    {
        PlayerStateMachine playerStateMachine = mario.getStateMachine();
        buffer++;
        if (buffer >= waitTime)  // Changed from == to >= to ensure it triggers
        {
            buffer = 0;
            currentFrame++;
            if (currentFrame >= numOfFrames)
            {
                currentFrame = 0;
            }
        }

        if (bumping && !hasItemAppeared)
        {
            Boolean isItem = true;
            i_position = new Vector2(position.X, position.Y - 31);
            if (playerStateMachine.IsSmall())
            {
                item = new Mushroom(spriteBatch, itemTexture, i_position);
            }
            else if (playerStateMachine.IsBig())
            {
                Random rand = new Random();
                int r = rand.Next(10);
                if (r <= 6)
                {
                    item = new Fire(spriteBatch, itemTexture, i_position); 
                }
                else
                {
                    coin = new Coin(spriteBatch, itemTexture, i_position);
                    mario.AddCoin();
                    isItem = false;
                }
               
            }
            else if (playerStateMachine.IsFire())
            {
                Random rand = new Random();
               int r = rand.Next(10);
                if (r <= 3)
                {
                    item = new Star(spriteBatch, itemTexture, i_position);
                }
                else
                {
                    coin = new Coin(spriteBatch,itemTexture,i_position);
                    mario.AddCoin();
                    
                    isItem = false;
                    
                }
                
            }
            if (isItem)
            {
                game.entities.Add(item);
                
            }
            hasItemAppeared = true;
        }

        if (bumping && item != null)  // Added null check
        {
            item.update(gametime);
        }else if (bumping)
        {
            coin.Update(gametime);
        }
       
    }

    public void Draw(SpriteBatch spriteBatch2, Vector2 pos)
    {
        sourceRectangle = new Rectangle(
            (int)Start.X + width * currentFrame,  // Removed the reverse frame calculation
            (int)Start.Y,
            width,
            height
        );

        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        if (hasItemAppeared && item != null)
        {
            item.draw();
        }
        else if(hasItemAppeared)
        {
            coin.Draw();
             
        }
    }

    public Rectangle GetDestination()
    {
        return destinationRectangle;
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }
    public void bump()
    {

    }
    public void broke()
    {

    }
}