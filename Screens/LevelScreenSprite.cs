using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class LevelScreenSprite : ISprite
{
    private readonly float scale = 2f;
    private SpriteFont levelScreenFonts;

    private Vector2 LevelOneTextPosition;
    private Vector2 LevelTwoTextPosition;

    public LevelScreenSprite(SpriteFont levelScreenFonts)
    {
        this.levelScreenFonts = levelScreenFonts;

        LevelOneTextPosition = new Vector2(50, 100); // Position for Level 1
        LevelTwoTextPosition = new Vector2(50, 130); // Position for Level 2
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(levelScreenFonts, "LEVEL 1", LevelOneTextPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(levelScreenFonts, "LEVEL 2", LevelTwoTextPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
    }

    public Rectangle GetLevelOneRectangle()
    {
        Vector2 textSize = levelScreenFonts.MeasureString("LEVEL 1") * scale;
        return new Rectangle((int)LevelOneTextPosition.X, (int)LevelOneTextPosition.Y, (int)textSize.X, (int)textSize.Y);
    }

    public Rectangle GetLevelTwoRectangle()
    {
        Vector2 textSize = levelScreenFonts.MeasureString("LEVEL 2") * scale;
        return new Rectangle((int)LevelTwoTextPosition.X, (int)LevelTwoTextPosition.Y, (int)textSize.X, (int)textSize.Y);
    }
    public void Update(GameTime gameTime)
    {

    }
}
