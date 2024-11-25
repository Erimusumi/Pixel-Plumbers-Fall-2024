using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class LevelOne : ILevel
{
    private Game1 game;
    private Mario mario;
    private Luigi luigi;
    private TextureManager textureManager;
    private GameStateMachine gameStateMachine;
    private ContentManager Content;

    private List<IEntity> entities = new List<IEntity>();
    private List<IEntity> entitiesRemoved;

    private SpriteBatch spriteBatch;
    private Texture2D EnemyTexture;
    private Texture2D blockTexture;
    private Texture2D obstacleTexture;
    private Texture2D ItemsTexture;
    private Texture2D overworldTiles;
    private Texture2D danceTexture;

    private Layer lvl1backdrop;
    private Layer lvl1greenery;
    private Layer lvl1foreground;

    private List<ISpriteEnemy> Enemy = new List<ISpriteEnemy>();

    private List<IBlock> LuckyBlocks = new List<IBlock>();

    private List<IBlock> BrickBlocks = new List<IBlock>();

    private IBlock OWUsedBlockSprite;
    private IBlock OWBrokenBrickSprite;

    private IObstacle obstacle1;
    private IObstacle obstacle2;
    private IObstacle obstacle3;

    private IObstacle obstacle4;
    private IObstacle obstacle5;
    private IObstacle obstacle6;

    private Flag flag;
    private GameTime gameTime;
    private Texture2D box;
    public LevelOne(
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
        this.danceTexture = textureManager.GetTexture("dance");
        box = textureManager.GetTexture("box");

        this.gameStateMachine = gameStateMachine;
        this.entities = entities;
        this.mario = mario;
        this.luigi = luigi;
        this.spriteBatch = spriteBatch;
        this.game = game;
        this.gameTime = gameTime;
        this.entitiesRemoved = entitiesRemoved;
        this.Content = Content;
    }

    public void InitializeLevel()
    {
        flag = new Flag(new Vector2(6335, 354),overworldTiles,danceTexture, spriteBatch);
        Enemy.Add(new Blooper(240, 200, mario));

        Enemy.Add(new Goomba(535, 370, (IPlayer)mario));
        Enemy.Add(new Goomba(1400, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(1700, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(1750, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(2500, 235, (IPlayer)mario));
        Enemy.Add(new Goomba(2600, 105, (IPlayer)mario));
        Enemy.Add(new Goomba(3000, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(3150, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(3520, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(3720, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(4000, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(4050, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(4110, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(4160, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(5400, 385, (IPlayer)mario));
        Enemy.Add(new Goomba(5550, 385, (IPlayer)mario));

        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(736, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(672, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(704, 160)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(512, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(2468, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3396, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3492, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3492, 160)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3588, 288)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(4132, 160)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(4164, 160)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3012, 160)
        ));
        LuckyBlocks.Add(new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(5444, 288)
        ));

        for (int i = 0; i < 33; i++)
        {
            BrickBlocks.Add(new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16)));
        }

        OWBrokenBrickSprite = new BrokenBrickSprite(blockTexture, 4, 1);

        obstacle1 = new obstacle1(obstacleTexture);
        obstacle2 = new obstacle2(obstacleTexture);
        obstacle3 = new obstacle3(obstacleTexture);
        obstacle4 = new obstacle4(obstacleTexture);
        obstacle6 = new obstacle1(obstacleTexture);

        foreach(var e in Enemy)
        {
            entities.Add(e);
        }
        foreach(var lucky in LuckyBlocks)
        {
            entities.Add(lucky);
        }
        foreach(var brick in BrickBlocks)
        {
            entities.Add(brick);
        }

        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);
        entities.Add(obstacle6);
        entities.Add(flag);


        if (gameStateMachine.isMultiplayer())
        {
            entities.Add(mario);
            entities.Add(luigi);
        }
        else if (gameStateMachine.isSingleplayer())
        {
            entities.Add(mario);
        }

        mario.SetSwimmingLevel(false);
        luigi.SetSwimmingLevel(false);
    

        lvl1backdrop = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Backdrop.csv");
        lvl1greenery = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Greenery.csv");
        lvl1foreground = new Layer(32, 16, 16, Content.RootDirectory + "/level1_Foreground.csv");

        lvl1backdrop.LoadLayer();
        lvl1greenery.LoadLayer();
        lvl1foreground.LoadLayer();
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

        for (int i = 0; i < 17; i++)
        {
            Enemy[i].Updates();
        }
        for(int i = 0; i < 13; i++)
        {
            LuckyBlocks[i].Update(gameTime);
        }
        for(int i = 0;i < 33; i++)
        {
            BrickBlocks[i].Update(gameTime);
        }

        obstacle1.Update();
        obstacle2.Update();
        obstacle3.Update();
        obstacle6.Update();
        flag.Update();
        
    }

    public void DrawLevel(SpriteBatch spriteBatch, FollowCamera camera)
    {
        lvl1backdrop.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        lvl1greenery.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        lvl1foreground.Draw(spriteBatch, overworldTiles, Vector2.Zero);
        flag.Draw();

        if (gameStateMachine.isMultiplayer())
        {
            mario.Draw(spriteBatch);
            luigi.Draw(spriteBatch);
        }
        else if (gameStateMachine.isSingleplayer())
        {
            mario.Draw(spriteBatch);
        }

        for (int i = 0; i < 17; i++)
        {
            Enemy[i].Draw(spriteBatch, EnemyTexture);
        }
        for (int i = 0; i < 13; i++)
        {
            LuckyBlocks[i].Draw(spriteBatch, new Vector2(69, 69));
        }

        BrickBlocks[0].Draw(spriteBatch, new Vector2(768, 288));
        BrickBlocks[1].Draw(spriteBatch, new Vector2(704, 288));
        BrickBlocks[2].Draw(spriteBatch, new Vector2(640, 288));
        BrickBlocks[3].Draw(spriteBatch, new Vector2(2436, 288));
        BrickBlocks[4].Draw(spriteBatch, new Vector2(2500, 288));
        BrickBlocks[5].Draw(spriteBatch, new Vector2(2532, 160));
        BrickBlocks[6].Draw(spriteBatch, new Vector2(2564, 160));
        BrickBlocks[7].Draw(spriteBatch, new Vector2(2596, 160));
        BrickBlocks[8].Draw(spriteBatch, new Vector2(2628, 160));
        BrickBlocks[9].Draw(spriteBatch, new Vector2(2660, 160));
        BrickBlocks[10].Draw(spriteBatch, new Vector2(2692, 160));
        BrickBlocks[11].Draw(spriteBatch, new Vector2(2724, 160));
        BrickBlocks[12].Draw(spriteBatch, new Vector2(2756, 160));
        BrickBlocks[13].Draw(spriteBatch, new Vector2(2788, 160));
        BrickBlocks[14].Draw(spriteBatch, new Vector2(2916, 160));
        BrickBlocks[15].Draw(spriteBatch, new Vector2(2948, 160));
        BrickBlocks[16].Draw(spriteBatch, new Vector2(2980, 160));
        BrickBlocks[17].Draw(spriteBatch, new Vector2(3012, 288));
        BrickBlocks[18].Draw(spriteBatch, new Vector2(3204, 288));
        BrickBlocks[19].Draw(spriteBatch, new Vector2(3236, 288));
        BrickBlocks[20].Draw(spriteBatch, new Vector2(3780, 288));
        BrickBlocks[21].Draw(spriteBatch, new Vector2(3876, 160));
        BrickBlocks[22].Draw(spriteBatch, new Vector2(3908, 160));
        BrickBlocks[23].Draw(spriteBatch, new Vector2(3940, 160));
        BrickBlocks[24].Draw(spriteBatch, new Vector2(4100, 160));
        BrickBlocks[25].Draw(spriteBatch, new Vector2(4192, 160));
        BrickBlocks[26].Draw(spriteBatch, new Vector2(4132, 288));
        BrickBlocks[27].Draw(spriteBatch, new Vector2(4164, 288));
        BrickBlocks[28].Draw(spriteBatch, new Vector2(3876, 160));
        BrickBlocks[29].Draw(spriteBatch, new Vector2(3908, 160));
        BrickBlocks[30].Draw(spriteBatch, new Vector2(5380, 288));
        BrickBlocks[31].Draw(spriteBatch, new Vector2(5412, 288));
        BrickBlocks[32].Draw(spriteBatch, new Vector2(5476, 288));

        obstacle1.Draw(spriteBatch, new Vector2(350, 370));
        obstacle2.Draw(spriteBatch, new Vector2(350 + 80, 350));
        obstacle3.Draw(spriteBatch, new Vector2(350 + 350, 335));
        obstacle6.Draw(spriteBatch, new Vector2(5740, 370));

        //spriteBatch.Draw(box, Goomba1.GetDestination(), Color.White);
    }

    public List<IEntity> GetAllEntities()
    {
        return new List<IEntity>(entities);
    }

    public List<Rectangle> GetLevelFloorRectangles()
    {
        return lvl1foreground.GetRedRectangles();
    }
}
