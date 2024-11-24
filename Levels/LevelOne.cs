using System.Collections.Generic;
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

    private ISpriteEnemy Goomba1;
    private ISpriteEnemy Goomba2;
    private ISpriteEnemy Goomba3;
    private ISpriteEnemy Goomba4;
    private ISpriteEnemy Goomba5;
    private ISpriteEnemy Goomba6;
    private ISpriteEnemy Goomba7;
    private ISpriteEnemy Goomba8;
    private ISpriteEnemy Goomba9;
    private ISpriteEnemy Goomba10;
    private ISpriteEnemy Goomba11;
    private ISpriteEnemy Goomba12;
    private ISpriteEnemy Goomba13;
    private ISpriteEnemy Goomba14;
    private ISpriteEnemy Goomba15;
    private ISpriteEnemy Goomba16;
    private ISpriteEnemy Koopa1;
    private ISpriteEnemy Bloop1;

    private IBlock OWLuckyBlockSprite1;
    private IBlock OWLuckyBlockSprite2;
    private IBlock OWLuckyBlockSprite3;
    private IBlock OWLuckyBlockSprite4;
    private IBlock OWLuckyBlockSprite5;
    private IBlock OWLuckyBlockSprite6;
    private IBlock OWLuckyBlockSprite7;
    private IBlock OWLuckyBlockSprite8;
    private IBlock OWLuckyBlockSprite9;
    private IBlock OWLuckyBlockSprite10;
    private IBlock OWLuckyBlockSprite11;
    private IBlock OWLuckyBlockSprite12;
    private IBlock OWLuckyBlockSprite13;

    private IBlock OWBrickBlockSprite1;
    private IBlock OWBrickBlockSprite2;
    private IBlock OWBrickBlockSprite3;
    private IBlock OWBrickBlockSprite4;
    private IBlock OWBrickBlockSprite5;
    private IBlock OWBrickBlockSprite6;
    private IBlock OWBrickBlockSprite7;
    private IBlock OWBrickBlockSprite8;
    private IBlock OWBrickBlockSprite9;
    private IBlock OWBrickBlockSprite10;
    private IBlock OWBrickBlockSprite11;
    private IBlock OWBrickBlockSprite12;
    private IBlock OWBrickBlockSprite13;
    private IBlock OWBrickBlockSprite14;
    private IBlock OWBrickBlockSprite15;
    private IBlock OWBrickBlockSprite16;
    private IBlock OWBrickBlockSprite17;
    private IBlock OWBrickBlockSprite18;
    private IBlock OWBrickBlockSprite19;
    private IBlock OWBrickBlockSprite20;
    private IBlock OWBrickBlockSprite21;
    private IBlock OWBrickBlockSprite22;
    private IBlock OWBrickBlockSprite23;
    private IBlock OWBrickBlockSprite24;
    private IBlock OWBrickBlockSprite25;
    private IBlock OWBrickBlockSprite26;
    private IBlock OWBrickBlockSprite27;
    private IBlock OWBrickBlockSprite28;
    private IBlock OWBrickBlockSprite29;
    private IBlock OWBrickBlockSprite30;
    private IBlock OWBrickBlockSprite31;
    private IBlock OWBrickBlockSprite32;
    private IBlock OWBrickBlockSprite33;

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
        
        Bloop1 = new Blooper(240, 200, mario);

        Goomba1 = new Goomba(535, 385, (IPlayer)mario, gameTime);
        Goomba2 = new Goomba(1400, 385, (IPlayer)mario, gameTime);
        Goomba3 = new Goomba(1700, 385, (IPlayer)mario, gameTime);
        Goomba4 = new Goomba(1750, 385, (IPlayer)mario, gameTime);
        Goomba5 = new Goomba(2500, 235, (IPlayer)mario, gameTime);
        Goomba6 = new Goomba(2600, 105, (IPlayer)mario, gameTime);
        Goomba7 = new Goomba(3000, 385, (IPlayer)mario, gameTime);
        Goomba8 = new Goomba(3150, 385, (IPlayer)mario, gameTime);
        Goomba9 = new Goomba(3520, 385, (IPlayer)mario, gameTime);
        Goomba10 = new Goomba(3720, 385, (IPlayer)mario, gameTime);
        Goomba11 = new Goomba(4000, 385, (IPlayer)mario, gameTime);
        Goomba12 = new Goomba(4050, 385, (IPlayer)mario, gameTime);
        Goomba13 = new Goomba(4110, 385, (IPlayer)mario, gameTime);
        Goomba14 = new Goomba(4160, 385, (IPlayer)mario, gameTime);
        Goomba15 = new Goomba(5400, 385, (IPlayer)mario, gameTime);
        Goomba16 = new Goomba(5550, 385, (IPlayer)mario, gameTime);

        OWLuckyBlockSprite1 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(736, 288)
        );
        OWLuckyBlockSprite2 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(672, 288)
        );
        OWLuckyBlockSprite3 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(704, 160)
        );
        OWLuckyBlockSprite4 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(512, 288)
        );
        OWLuckyBlockSprite5 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(2468, 288)
        );
        OWLuckyBlockSprite6 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3396, 288)
        );
        OWLuckyBlockSprite7 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3492, 288)
        );
        OWLuckyBlockSprite8 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3492, 160)
        );
        OWLuckyBlockSprite9 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3588, 288)
        );
        OWLuckyBlockSprite10 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(4132, 160)
        );
        OWLuckyBlockSprite11 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(4164, 160)
        );
        OWLuckyBlockSprite12 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(3012, 160)
        );
        OWLuckyBlockSprite13 = new LuckyBlockSprite(
            blockTexture,
            spriteBatch,
            ItemsTexture,
            game,
            mario,
            new Vector2(5444, 288)
        );

        OWBrickBlockSprite1 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite2 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite3 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite4 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite5 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite6 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite7 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite8 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite9 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite10 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite11 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite12 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite13 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite14 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite15 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite16 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite17 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite18 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite19 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite20 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite21 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite22 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite23 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite24 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite25 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite26 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite27 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite28 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite29 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite30 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite31 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite32 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite33 = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));

        OWBrokenBrickSprite = new BrokenBrickSprite(blockTexture, 4, 1);

        obstacle1 = new obstacle1(obstacleTexture);
        obstacle2 = new obstacle2(obstacleTexture);
        obstacle3 = new obstacle3(obstacleTexture);
        obstacle4 = new obstacle4(obstacleTexture);
        obstacle6 = new obstacle1(obstacleTexture);

        entities.Add(Goomba1);
        entities.Add(Goomba2);
        entities.Add(Goomba3);
        entities.Add(Goomba4);
        entities.Add(Goomba5);
        entities.Add(Goomba6);
        entities.Add(Goomba7);
        entities.Add(Goomba8);
        entities.Add(Goomba9);
        entities.Add(Goomba10);
        entities.Add(Goomba11);
        entities.Add(Goomba12);
        entities.Add(Goomba13);
        entities.Add(Goomba14);
        entities.Add(Goomba15);
        entities.Add(Goomba16);
        entities.Add(Bloop1);

        entities.Add(OWLuckyBlockSprite1);
        entities.Add(OWLuckyBlockSprite2);
        entities.Add(OWLuckyBlockSprite3);
        entities.Add(OWLuckyBlockSprite4);
        entities.Add(OWLuckyBlockSprite5);
        entities.Add(OWLuckyBlockSprite6);
        entities.Add(OWLuckyBlockSprite7);
        entities.Add(OWLuckyBlockSprite8);
        entities.Add(OWLuckyBlockSprite9);
        entities.Add(OWLuckyBlockSprite10);
        entities.Add(OWLuckyBlockSprite11);
        entities.Add(OWLuckyBlockSprite12);
        entities.Add(OWLuckyBlockSprite13);

        entities.Add(OWBrickBlockSprite1);
        entities.Add(OWBrickBlockSprite2);
        entities.Add(OWBrickBlockSprite3);
        entities.Add(OWBrickBlockSprite4);
        entities.Add(OWBrickBlockSprite5);
        entities.Add(OWBrickBlockSprite6);
        entities.Add(OWBrickBlockSprite7);
        entities.Add(OWBrickBlockSprite8);
        entities.Add(OWBrickBlockSprite9);
        entities.Add(OWBrickBlockSprite10);
        entities.Add(OWBrickBlockSprite11);
        entities.Add(OWBrickBlockSprite12);
        entities.Add(OWBrickBlockSprite13);
        entities.Add(OWBrickBlockSprite14);
        entities.Add(OWBrickBlockSprite15);
        entities.Add(OWBrickBlockSprite16);
        entities.Add(OWBrickBlockSprite17);
        entities.Add(OWBrickBlockSprite18);
        entities.Add(OWBrickBlockSprite19);
        entities.Add(OWBrickBlockSprite20);
        entities.Add(OWBrickBlockSprite21);
        entities.Add(OWBrickBlockSprite22);
        entities.Add(OWBrickBlockSprite23);
        entities.Add(OWBrickBlockSprite24);
        entities.Add(OWBrickBlockSprite25);
        entities.Add(OWBrickBlockSprite26);
        entities.Add(OWBrickBlockSprite27);
        entities.Add(OWBrickBlockSprite28);
        entities.Add(OWBrickBlockSprite29);
        entities.Add(OWBrickBlockSprite30);
        entities.Add(OWBrickBlockSprite31);
        entities.Add(OWBrickBlockSprite32);
        entities.Add(OWBrickBlockSprite33);

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
    }

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


        Goomba1.Updates();
        Goomba2.Updates();
        Goomba3.Updates();
        Goomba4.Updates();
        Goomba5.Updates();
        Goomba6.Updates();
        Goomba7.Updates();
        Goomba8.Updates();
        Goomba9.Updates();
        Goomba10.Updates();
        Goomba11.Updates();
        Goomba12.Updates();
        Goomba13.Updates();
        Goomba14.Updates();
        Goomba15.Updates();
        Goomba16.Updates();
        Bloop1.Updates();

        OWLuckyBlockSprite1.Update(gameTime);
        OWLuckyBlockSprite2.Update(gameTime);
        OWLuckyBlockSprite3.Update(gameTime);
        OWLuckyBlockSprite4.Update(gameTime);
        OWLuckyBlockSprite5.Update(gameTime);
        OWLuckyBlockSprite6.Update(gameTime);
        OWLuckyBlockSprite7.Update(gameTime);
        OWLuckyBlockSprite8.Update(gameTime);
        OWLuckyBlockSprite9.Update(gameTime);
        OWLuckyBlockSprite10.Update(gameTime);
        OWLuckyBlockSprite11.Update(gameTime);
        OWLuckyBlockSprite12.Update(gameTime);
        OWLuckyBlockSprite13.Update(gameTime);

        OWBrickBlockSprite1.Update(gameTime);
        OWBrickBlockSprite2.Update(gameTime);
        OWBrickBlockSprite3.Update(gameTime);
        OWBrickBlockSprite4.Update(gameTime);
        OWBrickBlockSprite5.Update(gameTime);
        OWBrickBlockSprite6.Update(gameTime);
        OWBrickBlockSprite7.Update(gameTime);
        OWBrickBlockSprite8.Update(gameTime);
        OWBrickBlockSprite9.Update(gameTime);
        OWBrickBlockSprite10.Update(gameTime);
        OWBrickBlockSprite11.Update(gameTime);
        OWBrickBlockSprite12.Update(gameTime);
        OWBrickBlockSprite13.Update(gameTime);
        OWBrickBlockSprite14.Update(gameTime);
        OWBrickBlockSprite15.Update(gameTime);
        OWBrickBlockSprite16.Update(gameTime);
        OWBrickBlockSprite17.Update(gameTime);
        OWBrickBlockSprite18.Update(gameTime);
        OWBrickBlockSprite19.Update(gameTime);
        OWBrickBlockSprite20.Update(gameTime);
        OWBrickBlockSprite21.Update(gameTime);
        OWBrickBlockSprite22.Update(gameTime);
        OWBrickBlockSprite23.Update(gameTime);
        OWBrickBlockSprite24.Update(gameTime);
        OWBrickBlockSprite25.Update(gameTime);
        OWBrickBlockSprite26.Update(gameTime);
        OWBrickBlockSprite27.Update(gameTime);
        OWBrickBlockSprite28.Update(gameTime);
        OWBrickBlockSprite29.Update(gameTime);
        OWBrickBlockSprite30.Update(gameTime);
        OWBrickBlockSprite31.Update(gameTime);
        OWBrickBlockSprite32.Update(gameTime);
        OWBrickBlockSprite33.Update(gameTime);

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

        Goomba1.Draw(spriteBatch, EnemyTexture);
        Goomba2.Draw(spriteBatch, EnemyTexture);
        Goomba3.Draw(spriteBatch, EnemyTexture);
        Goomba4.Draw(spriteBatch, EnemyTexture);
        Goomba5.Draw(spriteBatch, EnemyTexture);
        Goomba6.Draw(spriteBatch, EnemyTexture);
        Goomba7.Draw(spriteBatch, EnemyTexture);
        Goomba8.Draw(spriteBatch, EnemyTexture);
        Goomba9.Draw(spriteBatch, EnemyTexture);
        Goomba10.Draw(spriteBatch, EnemyTexture);
        Goomba11.Draw(spriteBatch, EnemyTexture);
        Goomba12.Draw(spriteBatch, EnemyTexture);
        Goomba13.Draw(spriteBatch, EnemyTexture);
        Goomba14.Draw(spriteBatch, EnemyTexture);
        Goomba15.Draw(spriteBatch, EnemyTexture);
        Goomba16.Draw(spriteBatch, EnemyTexture);
        Bloop1.Draw(spriteBatch, EnemyTexture);

        OWLuckyBlockSprite1.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite2.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite3.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite4.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite5.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite6.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite7.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite8.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite9.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite10.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite11.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite12.Draw(spriteBatch, new Vector2(69, 69));
        OWLuckyBlockSprite13.Draw(spriteBatch, new Vector2(69, 69));

        OWBrickBlockSprite1.Draw(spriteBatch, new Vector2(768, 288));
        OWBrickBlockSprite2.Draw(spriteBatch, new Vector2(704, 288));
        OWBrickBlockSprite3.Draw(spriteBatch, new Vector2(640, 288));
        OWBrickBlockSprite4.Draw(spriteBatch, new Vector2(2436, 288));
        OWBrickBlockSprite5.Draw(spriteBatch, new Vector2(2500, 288));
        OWBrickBlockSprite6.Draw(spriteBatch, new Vector2(2532, 160));
        OWBrickBlockSprite7.Draw(spriteBatch, new Vector2(2564, 160));
        OWBrickBlockSprite8.Draw(spriteBatch, new Vector2(2596, 160));
        OWBrickBlockSprite9.Draw(spriteBatch, new Vector2(2628, 160));
        OWBrickBlockSprite10.Draw(spriteBatch, new Vector2(2660, 160));
        OWBrickBlockSprite11.Draw(spriteBatch, new Vector2(2692, 160));
        OWBrickBlockSprite12.Draw(spriteBatch, new Vector2(2724, 160));
        OWBrickBlockSprite13.Draw(spriteBatch, new Vector2(2756, 160));
        OWBrickBlockSprite14.Draw(spriteBatch, new Vector2(2788, 160));
        OWBrickBlockSprite15.Draw(spriteBatch, new Vector2(2916, 160));
        OWBrickBlockSprite16.Draw(spriteBatch, new Vector2(2948, 160));
        OWBrickBlockSprite17.Draw(spriteBatch, new Vector2(2980, 160));
        OWBrickBlockSprite18.Draw(spriteBatch, new Vector2(3012, 288));
        OWBrickBlockSprite19.Draw(spriteBatch, new Vector2(3204, 288));
        OWBrickBlockSprite20.Draw(spriteBatch, new Vector2(3236, 288));
        OWBrickBlockSprite21.Draw(spriteBatch, new Vector2(3780, 288));
        OWBrickBlockSprite22.Draw(spriteBatch, new Vector2(3876, 160));
        OWBrickBlockSprite23.Draw(spriteBatch, new Vector2(3908, 160));
        OWBrickBlockSprite24.Draw(spriteBatch, new Vector2(3940, 160));
        OWBrickBlockSprite25.Draw(spriteBatch, new Vector2(4100, 160));
        OWBrickBlockSprite26.Draw(spriteBatch, new Vector2(4192, 160));
        OWBrickBlockSprite27.Draw(spriteBatch, new Vector2(4132, 288));
        OWBrickBlockSprite28.Draw(spriteBatch, new Vector2(4164, 288));
        OWBrickBlockSprite29.Draw(spriteBatch, new Vector2(3876, 160));
        OWBrickBlockSprite30.Draw(spriteBatch, new Vector2(3908, 160));
        OWBrickBlockSprite31.Draw(spriteBatch, new Vector2(5380, 288));
        OWBrickBlockSprite32.Draw(spriteBatch, new Vector2(5412, 288));
        OWBrickBlockSprite33.Draw(spriteBatch, new Vector2(5476, 288));

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
