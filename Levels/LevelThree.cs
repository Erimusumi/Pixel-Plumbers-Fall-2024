using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Pixel_Plumbers_Fall_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LevelThree:ILevel
{
    private Game1 game;
    private Rectangle screen = new Rectangle(0, 0, 800, 480);
    private List<IEntity> entities = new List<IEntity>();
    private List<IBlock> blocks;
    private Mario mario;
    GameTime gameTime;
    List<IEntity> entitiesRemoved;

    private SpriteBatch spriteBatch;

    private Texture2D EnemyTexture;
    private Texture2D blockTexture;
    private Texture2D obstacleTexture;
    private Texture2D ItemsTexture;

    //Enemy List: 

    //Block List:

    //Obstacle List:

    public LevelThree(
       Game1 game,
       List<IEntity> entities,
       Mario mario,
       Texture2D EnemyTexture,
       Texture2D blockTexture,
       Texture2D obstacleTexture,
       Texture2D ItemsTexture,
       SpriteBatch spriteBatch,
       GameTime gameTime,
List<IEntity> entitiesRemoved

   )
    {
        this.entities = entities;
        this.mario = mario;
        this.EnemyTexture = EnemyTexture;
        this.blockTexture = blockTexture;
        this.ItemsTexture = ItemsTexture;
        this.obstacleTexture = obstacleTexture;
        this.spriteBatch = spriteBatch;
        this.game = game;
        this.gameTime = gameTime;
        this.entitiesRemoved = entitiesRemoved;
    }
    public void InitializeLevel()
    {

    }
    public void LoadLevel(ContentManager content)
    {

    }
    public void UpdateLevel(GameTime gameTime)
    {

    }
    public void DrawLevel(SpriteBatch sB, FollowCamera camera)
    {

    }

}
