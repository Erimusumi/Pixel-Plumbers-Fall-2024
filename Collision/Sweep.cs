using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Pixel_Plumbers_Fall_2024;

public class Sweep
{
    GameTime gameTime;
    public Sweep(GameTime gameTime)
    {
        this.gameTime = gameTime;
    }
    public enum CollisionType { Top, Bottom, Left, Right, DontCare };

    private Boolean ContainsEnemy(List<IEntity> entities, int index)
    {
        Boolean containsEnemy = false;
        Type type = entities[index].GetType();
        if (type == typeof(Goomba) || type == typeof(Goomba2) || type == typeof(Koopa) || type == typeof(Cheeps))
        {
            containsEnemy = true;
            Debug.WriteLine("ContainsEnemy is true");
        }
        return containsEnemy;
    }

    private Boolean ContainsBlock(List<IEntity> entities, int index)
    {
        Boolean containsBlock = false;
        Type type = entities[index].GetType();
        if(type == typeof(BrokenBrickSprite) || type == typeof(LuckyBlockSprite) || type == typeof(StaticBlockSprite))
        {
            containsBlock = true;
            Debug.WriteLine("Contains Block is true");
        }
        return containsBlock;
    }

    private Boolean ContainsObstacle(List<IEntity> entities, int index)
    {
        Boolean containsObstacle = false;
        Type type = entities[index].GetType();
        if (type == typeof(obstacle1) || type == typeof(obstacle2) || type == typeof(obstacle3))
        {
            containsObstacle = true;
        }
        return containsObstacle;
    }
    private Boolean ContainsItem(List<IEntity> entities, int index)
    {
        Boolean containsItem = false;
        Type type = entities[index].GetType();
        if (type == typeof(Mushroom) || type == typeof(Star) || type == typeof(Fire))
        {
            containsItem  = true;
        }
        return containsItem;
    }
    private Boolean ContainsGround(List<IEntity> entities, int index)
    {
        Boolean containsGround = false;
        Type type = entities[index].GetType();
        if (type == typeof(Ground) )
        {
            containsGround = true;
        }
        return containsGround;
    }


    EnemyMarioInteraction EnemyMarioInteraction;
    OtherEnemyInteraction OtherEnemyInteraction;
    EnemyFireballInteraction EnemyFireballInteraction;
    MarioFirePowerInteraction MarioFirePowerInteraction;
    MarioMushroomInteraction MarioMushroomInteraction;
    MarioStarInteraction MarioStarInteraction;
    BlockFireballInteraction BlockFireballInteraction;
    MarioBlockInteraction MarioBlockInteraction;
    MarioObstacleInteraction MarioObstacleInteraction;
    ItemObstacleInteraction ItemObstacleInteraction;
    ItemBlockInteraction ItemBlockInteraction;
    EnemyObstacleInteraction EnemyObstacleInteraction;
    MarioItemInteraction MarioItemInteraction;
   

    public void iterateListInteractions(List<IEntity> entities, List<IEntity> entitiesRemoved)
    {
        int item1 = 0;
        int item2 = 1;
        if(entities.Count > 1)
        {
            while (item1 < entities.Count  &&  item2 < entities.Count )
            {
                handleInteraction(entities, entitiesRemoved, item1, item2);
                item1++;
                item2++;
            }
        }
    }
    private void handleInteraction(List<IEntity> entities, List<IEntity> entitiesRemoved, int index1, int index2)
    {

        /*Should determine the interactionType of two entities and call the appropriate method */
        IEntity item1 = entities[index1];
        IEntity item2 = entities[index2];

        //System.Diagnostics.Debug.WriteLine(item1.GetType() == typeof(Goomba));
        if (ContainsEnemy(entities, index1) && item2.GetType() == typeof(Mario))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item1, (Mario)item2, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()), entitiesRemoved);
            EnemyMarioInteraction.Update();

        }
        else if (item1.GetType() == typeof(Mario) && ContainsEnemy(entities, index2))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item2, (Mario)item1, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()), entitiesRemoved);
            EnemyMarioInteraction.Update();

        }

        else if (ContainsEnemy(entities, index1) && item2.GetType() == typeof(Fireball))
        {
            EnemyFireballInteraction = new EnemyFireballInteraction((Fireball)item2, (ISpriteEnemy)item1, entities, entitiesRemoved);
            EnemyFireballInteraction.update();
        }
        else if (ContainsEnemy(entities, index2) && item1.GetType() == typeof(Fireball))
        {
            EnemyFireballInteraction = new EnemyFireballInteraction((Fireball)item1, (ISpriteEnemy)item2, entities, entitiesRemoved);
            EnemyFireballInteraction.update();
        }
        else if (ContainsEnemy(entities, index1) && (ContainsEnemy(entities, index2)))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item1, item2);
            OtherEnemyInteraction.Update();
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item2, item1);
            OtherEnemyInteraction.Update();
        }
        else if (ContainsEnemy(entities, index1))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item1, item2);
            OtherEnemyInteraction.Update();
        }
        else if (ContainsEnemy(entities, index2))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item2, item1);
            OtherEnemyInteraction.Update();
        } /*else if (item1.GetType() == typeof(Star) && item2.GetType() == typeof(Mario))         //Item interaction
        {
            MarioStarInteraction = new MarioStarInteraction((Mario)item2, (Star)item1, entitiesRemoved);
            MarioStarInteraction.update();
            entities.RemoveAt(index1);
        }
        else if (item1.GetType() == typeof(Mario) && item2.GetType() == typeof(Star))
        {
            MarioStarInteraction = new MarioStarInteraction((Mario)item1, (Star)item2, entitiesRemoved);
            MarioStarInteraction.update();
            entities.RemoveAt(index2);
        }
        */
        else if (item1.GetType() == typeof(Fire) && item2.GetType() == typeof(Mario))
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item2, (Fire)item1, entitiesRemoved);
            MarioFirePowerInteraction.update();
            entities.RemoveAt(index1);
        }
        else if (item2.GetType() == typeof(Fire) && item1.GetType() == typeof(Mario))
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item1, (Fire)item2, entitiesRemoved);
            MarioFirePowerInteraction.update();
            entities.RemoveAt(index2);
        }
        /*else if (item1.GetType() == typeof(Mushroom) && item2.GetType() == typeof(Mario))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item2, (Mushroom)item1, entitiesRemoved);
            MarioMushroomInteraction.update();
            
            entities.RemoveAt(index1);
        } else if (item1.GetType() == typeof(Mario) && item1.GetType() == typeof(Mushroom))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item1, (Mushroom)item2, entitiesRemoved);
            MarioMushroomInteraction.update();
            

            entities.RemoveAt(index2);
        }
        */

        else if (ContainsItem(entities, index1) && item2.GetType() == typeof(Mario))
        {
            MarioItemInteraction = new MarioItemInteraction((IItem)item1, (Mario)item2, entitiesRemoved);
            System.Diagnostics.Debug.Write("MarioItemInteraction works");
        }
        else if (item1.GetType() == typeof(Mario) && ContainsItem(entities, index2))
        {
            MarioItemInteraction = new MarioItemInteraction((IItem)item2, (Mario)item1, entitiesRemoved);
            System.Diagnostics.Debug.Write("MarioItemInteraction works");
        }
        else if (ContainsObstacle(entities, index1) && ContainsItem(entities, index2))
        {
            ItemObstacleInteraction = new ItemObstacleInteraction((IItem)item2, (IObstacle)item1);
            ItemObstacleInteraction.update();
        }
        else if (ContainsObstacle(entities, index2) && ContainsItem(entities, index1))
        {
            ItemObstacleInteraction = new ItemObstacleInteraction((IItem)item1, (IObstacle)item2);
            ItemObstacleInteraction.update();

        }
        else if (ContainsBlock(entities, index1) && ContainsItem(entities, index2))
        {
            ItemBlockInteraction = new ItemBlockInteraction((IItem)item2, (IBlock)item1);
        }
        else if (ContainsBlock(entities, index2) && ContainsItem(entities, index1))
        {
            ItemBlockInteraction = new ItemBlockInteraction((IItem)item1, (IBlock)item2);
        }
        else if (ContainsItem(entities, index1) && ContainsBlock(entities, index2))
        {
            ItemBlockInteraction = new ItemBlockInteraction((IItem)item1, (IBlock)item2);
        }

        else if (item1.GetType() == typeof(Fireball) && ContainsBlock(entities, index2))
        {
            BlockFireballInteraction = new BlockFireballInteraction((Fireball)item1, (IBlock)item2, entitiesRemoved);
            BlockFireballInteraction.update();
        }
        else if (item2.GetType() == typeof(Fireball) && ContainsBlock(entities, index1))
        {
            BlockFireballInteraction = new BlockFireballInteraction((Fireball)item2, (IBlock)item1, entitiesRemoved);
            BlockFireballInteraction.update();
        }

         if (item1.GetType() == typeof(Mario) && ContainsBlock(entities, index2))
        {
            Debug.WriteLine("Mario Block Collision Detected");
            //handle block interaction
            
            Boolean luckyBlock = true;
            if (item2.GetType() == typeof(LuckyBlockSprite))
            {
                MarioBlockInteraction = new MarioBlockInteraction((Mario)item1, (IBlock)item2, luckyBlock);
            }
            else
            {
                luckyBlock = false;
                MarioBlockInteraction = new MarioBlockInteraction((Mario)item1, (IBlock)item2, luckyBlock);
            }
            MarioBlockInteraction.update();

        }
        else if (ContainsBlock(entities, index1) && item2.GetType() == typeof(Mario))
        {
            Debug.WriteLine("Mario Block Collision Detected");
            Boolean luckyBlock = true;
            if (item1.GetType() == typeof(LuckyBlockSprite))
            {
                MarioBlockInteraction = new MarioBlockInteraction((Mario)item2, (IBlock)item1, luckyBlock);
            }
            else
            {
                luckyBlock = false;
                MarioBlockInteraction = new MarioBlockInteraction((Mario)item2, (IBlock)item1, luckyBlock);
            }
            MarioBlockInteraction.update();

        }

        else if (item1.GetType() == typeof(Mario) && ContainsObstacle(entities, index2))
        {

            MarioObstacleInteraction = new MarioObstacleInteraction((Mario)item1, (IObstacle)item2, gameTime);
            MarioObstacleInteraction.update();

        }
        else if (ContainsObstacle(entities, index1) && item2.GetType() == typeof(Mario))
        {

            MarioObstacleInteraction = new MarioObstacleInteraction((Mario)item2, (IObstacle)item1, gameTime);
            MarioObstacleInteraction.update();

        }
        else if (ContainsEnemy(entities, index1) && ContainsObstacle(entities, index2))
        {
            EnemyObstacleInteraction = new EnemyObstacleInteraction((ISpriteEnemy)item1, (IObstacle)item2);
            EnemyObstacleInteraction.update();
        }
        else if (ContainsObstacle(entities, index1) && ContainsEnemy(entities, index2))
        {
            EnemyObstacleInteraction = new EnemyObstacleInteraction((ISpriteEnemy)item2, (IObstacle)item1);
            EnemyObstacleInteraction.update();
        }
    }
    public Rectangle getRectangle(List<IEntity> Entities, int index)
    {
        IEntity entity = Entities[index];
        Rectangle rectangle = new Rectangle();
        rectangle = entity.GetDestination();
        return rectangle;
    }
    public void Compare(List<IEntity> entities, List<IEntity> entitiesRemoved, Vector2 camera)
    {
        if (entities.Count > 1)
        {
            Rectangle firstEntity = entities[0].GetDestination();
            Rectangle secondEntity = entities[1].GetDestination();
            for (int i = 0; (i < entities.Count) && (firstEntity.X <= (800 + camera.X)); i++)
            {
                firstEntity = entities[i].GetDestination();
                for (int j = i+1; (j < entities.Count) && (secondEntity.X <= (800 + camera.X)); j++)
                {
                    secondEntity = entities[j].GetDestination();
                   
                    if (firstEntity.Intersects(secondEntity))
                    {
                        Debug.WriteLine("First Entity is: " + entities[i].ToString() + " Second Entity is " + entities[j].ToString()); 
                        handleInteraction(entities, entitiesRemoved, i, j);
                    }
                }
            }
        }

    }
}
