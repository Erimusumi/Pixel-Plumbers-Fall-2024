using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;

public class LevelOne : ILevel
{
    private Game1 game;
    private Rectangle screen = new Rectangle(0, 0, 800, 480);
    private List<IEntity> entities = new List<IEntity>();
    private List<IBlock> blocks;
    private Mario mario;

    private SpriteBatch spriteBatch;

    private Texture2D EnemyTexture;
    private Texture2D blockTexture;
    private Texture2D obstacleTexture;
    private Texture2D ItemsTexture;

    //Enemy list:
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

    //Block List:
    private IBlock OWLuckyBlockSprite;
    private IBlock OWLuckyBlockSprite2;
    private IBlock OWUsedBlockSprite;
    private IBlock OWBrickBlockSprite;
    private IBlock OWBrickBlockSprite2;
    private IBlock OWBrokenBrickSprite;

    //Obstacle List:
    private IObstacle obstacle1;
    private IObstacle obstacle2;
    private IObstacle obstacle3;

    public LevelOne(Game1 game, List<IEntity> entities, Mario mario, Texture2D EnemyTexture, Texture2D blockTexture, Texture2D obstacleTexture, Texture2D ItemsTexture, SpriteBatch spriteBatch)
    {
        this.entities = entities;
        this.mario = mario;
        this.EnemyTexture = EnemyTexture;
        this.blockTexture = blockTexture;
        this.ItemsTexture = ItemsTexture;
        this.obstacleTexture = obstacleTexture;
        this.spriteBatch = spriteBatch;
        this.game = game;

    }

    public void InitializeLevel()
    {
        // Initialize all entities:
        Goomba1 = new Goomba(535, 400);
        Goomba2 = new Goomba(1400, 400);
        Goomba3 = new Goomba(1700, 400);
        Goomba4 = new Goomba(1750, 400);
        Goomba5 = new Goomba(2500, 250);
        Goomba6 = new Goomba(2600, 120);
        Goomba7 = new Goomba(3000, 400);
        Goomba8 = new Goomba(3150, 400);
        Goomba9 = new Goomba(3520, 400);
        Goomba10 = new Goomba(3720, 400);
        Goomba11 = new Goomba(4000, 400);
        Goomba12 = new Goomba(4050, 400);
        Goomba13 = new Goomba(4110, 400);
        Goomba14 = new Goomba(4160, 400);
        Goomba15 = new Goomba(5400, 400);
        Goomba16 = new Goomba(5550, 400);

        Koopa1 = new Koopa(240, 400);
        Bloop1 = new Blooper(240, 200, mario);

        OWLuckyBlockSprite = new LuckyBlockSprite(blockTexture, spriteBatch, ItemsTexture, game, mario, new Vector2(200 + 62, 350));
        OWLuckyBlockSprite2 = new LuckyBlockSprite(blockTexture, spriteBatch, ItemsTexture, game, mario, new Vector2(200, 200));
        OWBrickBlockSprite = new StaticBlockSprite(blockTexture, new Rectangle(272, 112, 16, 16));
        OWBrickBlockSprite2 = new StaticBlockSprite(blockTexture, new Rectangle(400,200, 16, 16));
        OWBrokenBrickSprite = new BrokenBrickSprite(blockTexture, 4, 1);

        obstacle1 = new obstacle1(obstacleTexture);
        obstacle2 = new obstacle2(obstacleTexture);
        obstacle3 = new obstacle3(obstacleTexture);

        // Add entities to the list
        entities.Add(mario);
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

        entities.Add(Koopa1);
        entities.Add(Bloop1);

        entities.Add(OWLuckyBlockSprite);
        entities.Add(OWLuckyBlockSprite2);
        entities.Add(OWBrickBlockSprite);
        entities.Add(OWBrickBlockSprite2);
        entities.Add(OWBrokenBrickSprite);

        entities.Add(obstacle1);
        entities.Add(obstacle2);
        entities.Add(obstacle3);


    }

    public void LoadLevel(ContentManager content)
    {
        // Load level assets here
    }

    public void UpdateLevel(GameTime gameTime)
    {
        // Update all entities
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

        Koopa1.Updates();
        Bloop1.Updates();

        OWLuckyBlockSprite.Update(gameTime);
        OWLuckyBlockSprite2.Update(gameTime);
        OWBrickBlockSprite.Update(gameTime);
        OWBrickBlockSprite2.Update(gameTime);
        OWBrokenBrickSprite.Update(gameTime);

        obstacle1.Update();
        obstacle2.Update();
        obstacle3.Update();

        mario.isOnGround = false;
        mario.Update(gameTime);
    }

    public void DrawLevel(SpriteBatch spriteBatch, FollowCamera camera)
    {
        // Draw all entities
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

        Koopa1.Draw(spriteBatch, EnemyTexture);
        Bloop1.Draw(spriteBatch, EnemyTexture);

        mario.Draw(spriteBatch);

        OWLuckyBlockSprite2.Draw(spriteBatch, new Vector2(200, 200));
        OWBrickBlockSprite.Draw(spriteBatch, new Vector2(200, 350));
        OWBrickBlockSprite.Draw(spriteBatch, new Vector2(600, 240));
        OWBrokenBrickSprite.Draw(spriteBatch, new Vector2(200 + 31, 350));
        OWLuckyBlockSprite.Draw(spriteBatch, new Vector2(200 + 62, 350));

        obstacle1.Draw(spriteBatch, new Vector2(350, 370));
        obstacle2.Draw(spriteBatch, new Vector2(350 + 80, 350));
        obstacle3.Draw(spriteBatch, new Vector2(350 + 350, 335));
    }

    public List<IEntity> GetAllEntities()
    {
        return new List<IEntity>(entities);
    }
}
