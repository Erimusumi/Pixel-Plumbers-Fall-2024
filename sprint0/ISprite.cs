using Microsoft.Xna.Framework.Graphics;
using System.Numerics;

namespace sprint0
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch sb, Texture2D texture);
        void Draw(SpriteBatch sb, SpriteFont font);
    }
}