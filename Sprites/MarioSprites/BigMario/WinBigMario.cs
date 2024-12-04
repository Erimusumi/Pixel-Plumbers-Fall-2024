﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class WinBigMario : ICharacter
{
    private float scale = 2f;
    private Texture2D MarioTexture;
    private float AnimationTimer;
    private int AnimationSpeed;
    private int currentAnimationIndex = 0;
    private Color tint;

    private Rectangle[] FrameRectangles;

    public WinBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;

        AnimationTimer = 0;
        AnimationSpeed = 200;

        FrameRectangles = new Rectangle[2];
        FrameRectangles[0] = new Rectangle(363, 89, 14, 27); // Frame 1
        FrameRectangles[1] = new Rectangle(390, 88, 14, 30); // Frame 2

        currentAnimationIndex = 0;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, bool HasStar)
    {
        if (HasStar) { tint = Color.Magenta; }
        else { tint = Color.White; }

        spriteBatch.Draw(MarioTexture, position, FrameRectangles[currentAnimationIndex], tint, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public void Update(GameTime gameTime)
    {
        if (AnimationTimer > AnimationSpeed)
        {
            if (currentAnimationIndex == 1)
            {
                currentAnimationIndex = 0;
            }
            else
            {
                currentAnimationIndex = 1;
            }
            AnimationTimer = 0;
        }
        else
        {
            AnimationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }
    }

    public Rectangle GetDestination(Vector2 position)
    {
        return new Rectangle((int)position.X, (int)position.Y, FrameRectangles[currentAnimationIndex].Width * (int)scale, FrameRectangles[currentAnimationIndex].Height * (int)scale);
    }
}