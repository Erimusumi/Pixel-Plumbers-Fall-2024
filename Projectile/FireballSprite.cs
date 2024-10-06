using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireballSprite : ISprite
{
    private Texture2D texture;
    private float GameTicks;
    private int AnimationSpeed;
    private int previousAnimationIndex = 0;
    private int currentAnimationIndex = 0;

    private Rectangle[] FrameRectangles;
    public FireballSprite(Texture2D Texture)
    {
        this.texture = Texture;

        GameTicks = 0;
        AnimationSpeed = 100;

        FrameRectangles = new Rectangle[4];
        FrameRectangles[0] = new Rectangle(96, 144, 8, 8); // Frame 1
        FrameRectangles[1] = new Rectangle(104, 144, 8, 8); // Frame 2
        FrameRectangles[2] = new Rectangle(96, 152, 8, 8);  // Frame 3
        FrameRectangles[3] = new Rectangle(104, 152, 8, 8); // Frame 4

        previousAnimationIndex = 3;
        currentAnimationIndex = 2;
    }

    public void Load(GraphicsDeviceManager graphics)
    {

    }
    public void Update(GameTime gameTime)
    {
        GameTicks += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        if (GameTicks <= AnimationSpeed) return;

        currentAnimationIndex = currentAnimationIndex == 1
            ? (previousAnimationIndex == 0 ? 3 : 0)
            : 1;

        previousAnimationIndex = currentAnimationIndex;
        GameTicks = 0;
    }

    public void Draw(SpriteBatch sb, Vector2 pos)
    {
        sb.Draw(texture, pos, FrameRectangles[currentAnimationIndex], Color.White);
    }
}
