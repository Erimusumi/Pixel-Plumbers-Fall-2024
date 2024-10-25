using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class LevelSelectionScreen : ISprite
{
    private readonly float scale = 2f;
    private SpriteFont levelScreenFonts;

    private Vector2 LevelOneTextPosition;
    private Vector2 LevelTwoTextPosition;
    private Vector2 LevelThreeTextPosition;

    public LevelSelectionScreen(SpriteFont levelScreenFonts)
    {
        this.levelScreenFonts = levelScreenFonts;

        string LevelOneText = "LEVEL 1";
        string LevelTwoText = "LEVEL 2";
        string LevelThreeText = "LEVEL 3";

        Vector2 player1TextSize = levelScreenFonts.MeasureString(LevelOneText) * scale;
        Vector2 player2TextSize = levelScreenFonts.MeasureString(LevelTwoText) * scale;
        Vector2 helpTextSize = levelScreenFonts.MeasureString(LevelThreeText) * scale;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.DrawString(levelScreenFonts, "SINGLEPLAYER", new Vector2(240, 250), Color.White);
        spriteBatch.DrawString(levelScreenFonts, "MULTIPLAYER", new Vector2(260, 300), Color.White);
        spriteBatch.DrawString(levelScreenFonts, "HELP", new Vector2(360, 350), Color.White);
    }

    public Rectangle GetPlayer1Region()
    {
        return new Rectangle((int)LevelOneTextPosition.X, (int)LevelOneTextPosition.Y, (int)levelScreenFonts.MeasureString("1 PLAYER").X * (int)scale, (int)levelScreenFonts.MeasureString("LEVEL 1").Y * (int)scale);
    }

    public Rectangle GetPlayer2Region()
    {
        return new Rectangle((int)LevelTwoTextPosition.X, (int)LevelTwoTextPosition.Y, (int)levelScreenFonts.MeasureString("2 PLAYER").X * (int)scale, (int)levelScreenFonts.MeasureString("LEVEL 2").Y * (int)scale);
    }

    public Rectangle GetHelpRegion()
    {
        return new Rectangle((int)LevelThreeTextPosition.X, (int)LevelThreeTextPosition.Y, (int)levelScreenFonts.MeasureString("HELP").X * (int)scale, (int)levelScreenFonts.MeasureString("LEVEL 3").Y * (int)scale);
    }

    public void Update(GameTime gameTime)
    {

    }
}
