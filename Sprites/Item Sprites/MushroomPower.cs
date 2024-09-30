﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class MushroomPower : ISprite
{
    private Texture2D ItemTexture;
    public MushroomPower(Texture2D ItemTexture)
    {
        this.ItemTexture = ItemTexture;
    }
    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        Rectangle sourceRectangle = new Rectangle(220, 354, 65, 64);
        spriteBatch.Draw(ItemTexture, position, sourceRectangle, Color.White);
    }

    public void Load(GraphicsDeviceManager graphics)
    {
    }

    public void Update(GameTime gametime)
    {
    }
}