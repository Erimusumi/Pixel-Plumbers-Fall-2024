using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pixel_Plumbers_Fall_2024;


public class LevelTwo : ILevel


{
    private Game1 game;
    private Mario mario;
    private Luigi luigi;
    private TextureManager textureManager;
    private GameStateMachine gameStateMachine;
    private ContentManager Content;

    private List<IEntity> entities = new List<IEntity>();
    private List<IEntity> entitiesRemoved;
    private List<IEntity> floorRectangles;


    private SpriteBatch spriteBatch;
    private Texture2D EnemyTexture;
    private Texture2D blockTexture;
    private Texture2D obstacleTexture;
    private Texture2D ItemsTexture;
    private Texture2D overworldTiles;
    private Texture2D underwaterTiles;

    private Layer lvl2backdrop1;
    private Layer lvl2backdrop2;
    private Layer lvl2greenery;
    private Layer lvl2foreground1;
    private Layer lvl2foreground2;
    private FlagSprite flagSprite;

    public LevelTwo(
        Game1 game,
        Mario mario,
        Luigi luigi,
        List<IEntity> entities,
        List<IEntity> entitiesRemoved,
        SpriteBatch spriteBatch,
        GameTime gameTime,
        ContentManager Content,
        TextureManager textureManager,
        GameStateMachine gameStateMachine
    )

    {
        this.textureManager = textureManager;
        this.EnemyTexture = textureManager.GetTexture("Enemy");
        this.blockTexture = textureManager.GetTexture("Block");
        this.ItemsTexture = textureManager.GetTexture("Items");
        this.obstacleTexture = textureManager.GetTexture("Obstacle");
        this.overworldTiles = textureManager.GetTexture("OverworldTiles");
        this.underwaterTiles = textureManager.GetTexture("UnderwaterTiles");

        this.gameStateMachine = gameStateMachine;
        this.entities = entities;
        this.mario = mario;
        this.luigi = luigi;
        this.spriteBatch = spriteBatch;
        this.game = game;
        this.entitiesRemoved = entitiesRemoved;
        this.Content = Content;
    }


    public void InitializeLevel()
    {
        if (gameStateMachine.isMultiplayer())
        {
            entities.Add(mario);
            entities.Add(luigi);
        }
        else if (gameStateMachine.isSingleplayer())
        {
            entities.Add(mario);
        }

        lvl2backdrop1 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWBackdrop.csv");
        lvl2backdrop2 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_UWBackdrop.csv");
        lvl2greenery = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWGreenery.csv");
        lvl2foreground1 = new Layer(32, 16, 16, Content.RootDirectory + "/level2_OWForeground.csv");
        lvl2foreground2 = new Layer(32, 16, 16, Content.RootDirectory + "//level2_UWForeground.csv");

        lvl2backdrop1.LoadLayer();
        lvl2backdrop2.LoadLayer();
        lvl2greenery.LoadLayer();
        lvl2foreground1.LoadLayer();
        lvl2foreground2.LoadLayer();
    }
    public void UpdateLevel(GameTime gameTime)
    {
        if (gameStateMachine.isMultiplayer())
        {
            mario.SetIsOnGround(false);
            mario.Update(gameTime);
            luigi.SetIsOnGround(false);
            luigi.Update(gameTime);
        }
        else if (gameStateMachine.isSingleplayer())
        {
            mario.SetIsOnGround(false);
            mario.Update(gameTime); ;
        }

        if(mario.marioPosition.X > 1){
            mario.SetPositionY(10);
        }
    }
    public void DrawLevel(SpriteBatch sB, FollowCamera camera)
    {
        lvl2backdrop1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        lvl2backdrop2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);
        lvl2greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        lvl2foreground1.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        lvl2foreground2.Draw(spriteBatch, underwaterTiles, Vector2.Zero);

        if (gameStateMachine.isMultiplayer())
        {
            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);
        }
        else if (gameStateMachine.isSingleplayer())
        {
            mario.Draw(spriteBatch);
        }
    }

    public List<Rectangle> GetLevelFloorRectangles()
    {
        return lvl2foreground1.GetRedRectangles();
    }
}
