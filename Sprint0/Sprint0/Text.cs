using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

public class Text
{

    public void Draw(SpriteBatch sb, SpriteFont Font)
    {
        sb.Begin();
        sb.DrawString(Font, "Program Made By: Dylan Moore", new Vector2(320, 390), Color.Black);
        sb.DrawString(Font, "Sprite URLS From:", new Vector2(320, 410), Color.Black);
        sb.DrawString(Font, "https://www.mariouniverse.com/wp-content/img/sprites/nes/smb/luigi.png\r\n", new Vector2(200, 430), Color.Black);

        sb.End();
    }
}