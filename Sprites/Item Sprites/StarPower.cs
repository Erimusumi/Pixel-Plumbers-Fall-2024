﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StarPower : ISprite
{
    private Texture2D ItemTexture;
    public StarPower(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(0, 48, 15, 15);
        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}