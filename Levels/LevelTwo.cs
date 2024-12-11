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
    private double startAnimationElapsedTime = 0;

    public Point mapSize = new(192 * 32, 30 * 32);
    private Layer lvl2backdrop1;
    private Layer lvl2backdrop2;
    private Layer lvl2greenery;
    private Layer lvl2foreground1;
    private Layer lvl2foreground2;
    private FlagSprite flagSprite;
    private FollowCamera followCamera;

    Boolean startAnimation = false;
    Boolean upPipeAnimation = false;

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
        GameStateMachine gameStateMachine,
        FollowCamera followCamera
    )

    {
        this.textureManager = textureManager;
        this.EnemyTexture = textureManager.GetTexture("Enemy");
        this.blockTexture = textureManager.GetTexture("Block");
        this.ItemsTexture = textureManager.GetTexture("Items");
        this.overworldTiles = textureManager.GetTexture("OverworldTiles");
        this.underwaterTiles = textureManager.GetTexture("UnderwaterTiles");
        this.followCamera = followCamera;
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
        entities.Add(mario);
        entities.Add(luigi);

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
        startAnimation = false;
    }

    public void UpdateLevel(GameTime gameTime)
    {
        Console.WriteLine(mario.marioPosition);
        if (!startAnimation)
        {
            {
                mario.Stop();
                mario.Fall();
                mario.Fall();
                mario.Fall();
                mario.Fall();
                mario.Fall();
                mario.Fall();
                mario.Fall();
                luigi.Stop();

                luigi.Fall();
                luigi.Fall();
                luigi.Fall();
                luigi.Fall();
                luigi.Fall();
                luigi.Fall();
                luigi.Fall();

                mario.Update(gameTime);
                luigi.Update(gameTime);

                mario.marioPosition = new Vector2(70, 800);
                luigi.luigiPosition = new Vector2(40, 800);
                followCamera.SetYPosition();
                mario.SetSwimmingLevel(true);
                luigi.SetSwimmingLevel(true);
                startAnimation = true;
            }
        }


        if (mario.marioPosition.X > 6000 && mario.marioPosition.Y > 672 && mario.marioPosition.Y < 736)
        {
            upPipeAnimation = true;
        }

        if (upPipeAnimation == true)
        {
            mario.SetSwimmingLevel(false);
            luigi.SetSwimmingLevel(false);
            mario.marioPosition = new Vector2(5132, 270);
            luigi.luigiPosition = new Vector2(5132, 270);

            followCamera.setHigherCamera();
            mario.Update(gameTime);
            luigi.Update(gameTime);
            upPipeAnimation = false;
        }

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
    }

    public void DrawLevel(SpriteBatch sB)
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
        List<Rectangle> combinedFloorRectangles = new List<Rectangle>();
        combinedFloorRectangles.AddRange(lvl2foreground1.GetRedRectangles());
        combinedFloorRectangles.AddRange(lvl2foreground2.GetRedRectangles());
        return combinedFloorRectangles;
    }
}
