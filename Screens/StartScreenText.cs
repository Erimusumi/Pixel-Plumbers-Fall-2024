using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Pixel_Plumbers_Fall_2024;

public class StartScreenText : ISprite
{
    private SpriteFont MyFont;
    private Vector2 player1Position;
    private Vector2 player2Position;
    private Vector2 helpPosition;

    public StartScreenText(SpriteFont spriteFont)
    {
 
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(MyFont, "1 PLAYER", player1Position, Color.Black);
        spriteBatch.DrawString(MyFont, "2 PLAYER", player2Position, Color.Black);
        spriteBatch.DrawString(MyFont, "HELP", helpPosition, Color.Black);
    }

    public void Update(GameTime gameTime)
    {
    }


}
