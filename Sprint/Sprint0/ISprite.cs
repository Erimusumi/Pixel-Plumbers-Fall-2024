using Microsoft.Xna.Framework.Graphics;
using System;

public interface ISprite
{
    void Updates();
    void Draw(SpriteBatch sb, Texture2D Texture);
}
