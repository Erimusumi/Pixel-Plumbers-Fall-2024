using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class LevelOne : ILevel
{
    private Rectangle screen = new Rectangle(0, 0, 800, 480);
    private List<IEntity> entities = new List<IEntity>();
    private List<IBlock> blocks;
    private Mario mario;


    private Texture2D EnemyTexture;

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

    public LevelOne(List<IEntity> entities, Mario mario, Texture2D EnemyTexture)
    {
        this.entities = entities;
        this.mario = mario;
        this.EnemyTexture = EnemyTexture;
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
    }

    public List<IEntity> GetAllEntities()
    {
        return new List<IEntity>(entities);
    }
}
