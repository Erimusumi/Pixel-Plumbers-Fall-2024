using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TextureManager
{
    private Dictionary<string, Texture2D> textures;

    private Texture2D marioTexture;
    private Texture2D titleTexture;
    private Texture2D gameOverBackground;
    private Texture2D enemyTexture;
    private Texture2D itemsTexture;
    private Texture2D blockTexture;
    private Texture2D obstacleTexture;
    private Texture2D overworldTiles;
    private Texture2D underwaterTiles;
    private Texture2D tableTexture;
    private Texture2D tabletopTexture;
    private Texture2D cardsTexture;

    public TextureManager(ContentManager content)
    {
        textures = new Dictionary<string, Texture2D>();

        marioTexture = content.Load<Texture2D>("mario");
        titleTexture = content.Load<Texture2D>("supermariobros");
        gameOverBackground = content.Load<Texture2D>("blank screen");
        enemyTexture = content.Load<Texture2D>("enemies");
        itemsTexture = content.Load<Texture2D>("itemsAndPowerups");
        blockTexture = content.Load<Texture2D>("blocks");
        obstacleTexture = content.Load<Texture2D>("obstacle");
        overworldTiles = content.Load<Texture2D>("OverworldTilesv200");
        underwaterTiles = content.Load<Texture2D>("UnderwaterTiles");
        tableTexture = content.Load<Texture2D>("BlackJack/table");
        tabletopTexture = content.Load<Texture2D>("BlackJack/tabletop");
        cardsTexture = content.Load<Texture2D>("BlackJack/cards");

        textures["Mario"] = marioTexture;
        textures["Title"] = titleTexture;
        textures["GameOverBackground"] = gameOverBackground;
        textures["Enemy"] = enemyTexture;
        textures["Items"] = itemsTexture;
        textures["Block"] = blockTexture;
        textures["Obstacle"] = obstacleTexture;
        textures["OverworldTiles"] = overworldTiles;
        textures["UnderwaterTiles"] = underwaterTiles;
        textures["Table"] = tableTexture;
        textures["TableTop"] = tabletopTexture;
        textures["Cards"] = cardsTexture;
    }

    public Texture2D GetTexture(string textureName)
    {
        if (textures.TryGetValue(textureName, out var texture))
        {
            return texture;
        }
        throw new KeyNotFoundException($"Texture '{textureName}' not found.");
    }
}
