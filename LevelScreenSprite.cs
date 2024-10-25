using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class LevelScreenSprite : ISprite
{
    private readonly float scale = 2f;
    private SpriteFont levelScreenFonts;

    private Vector2 LevelOneTextPosition;
    private Vector2 LevelTwoTextPosition;
    private Vector2 LevelThreeTextPosition;

    public LevelScreenSprite(SpriteFont levelScreenFonts)
    {
        this.levelScreenFonts = levelScreenFonts;

        // Initialize text strings
        string LevelOneText = "LEVEL 1";
        string LevelTwoText = "LEVEL 2";
        string LevelThreeText = "LEVEL 3";

        LevelOneTextPosition = new Vector2(100, 200); // Position for Level 1
        LevelTwoTextPosition = new Vector2(100, 250); // Position for Level 2
        LevelThreeTextPosition = new Vector2(100, 300); // Position for Level 3
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(levelScreenFonts, "LEVEL 1", LevelOneTextPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(levelScreenFonts, "LEVEL 2", LevelTwoTextPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        spriteBatch.DrawString(levelScreenFonts, "LEVEL 3", LevelThreeTextPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
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

    public Rectangle GetLevelThreeRectangle()
    {
        Vector2 textSize = levelScreenFonts.MeasureString("LEVEL 3") * scale;
        return new Rectangle((int)LevelThreeTextPosition.X, (int)LevelThreeTextPosition.Y, (int)textSize.X, (int)textSize.Y);
    }

    public void Update(GameTime gameTime)
    {

    }
}
