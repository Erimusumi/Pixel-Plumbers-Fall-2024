﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SmallIdleLeftMario : ISprite
{
    private Texture2D MarioTexture;
    public SmallIdleLeftMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(181, 0, 12, 15);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}