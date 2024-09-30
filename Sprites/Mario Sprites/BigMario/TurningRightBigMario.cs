﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TurningRightBigMario : IMarioSprite
{
    private Texture2D MarioTexture;
    public TurningRightBigMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(60, 52, 75 - 60, 83 - 52);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Update(GameTime gametime)
    {
    }
}