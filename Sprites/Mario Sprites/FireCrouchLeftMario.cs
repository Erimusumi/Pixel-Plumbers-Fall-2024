﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FireCrouchLeftMario : ISprite
{
    private Texture2D MarioTexture;
    public FireCrouchLeftMario(Texture2D MarioTexture)
    {
        this.MarioTexture = MarioTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        //TODO: get correct sprite source
        Rectangle sourceRectangle = new Rectangle(0, 127, 16, 22);
        spriteBatch.Draw(MarioTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}