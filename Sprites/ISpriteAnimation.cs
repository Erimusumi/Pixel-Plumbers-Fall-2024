using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public interface ISpriteAnimation : IEntity
{
    void Updates();
    void Draw(SpriteBatch sb, Texture2D Texture);

}
