using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Pixel_Plumbers_Fall_2024;

public class Sweep
{
    public enum CollisionType { Top, Bottom, Left, Right, DontCare };

    private Boolean ContainsEnemy(List<IEntity> entities, int index)
    {
        Boolean containsEnemy = false;
        Type type = entities[index].GetType();
        if (type == typeof(Goomba) || type == typeof(Goomba2) || type == typeof(Koopa) || type == typeof(Cheeps))
        {
            containsEnemy = true;
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
        }
        return containsBlock;
    }


    EnemyMarioInteraction EnemyMarioInteraction;
    OtherEnemyInteraction OtherEnemyInteraction;
    EnemyFireballInteraction EnemyFireballInteraction;
    MarioFirePowerInteraction MarioFirePowerInteraction;
    MarioMushroomInteraction MarioMushroomInteraction;
    MarioStarInteraction MarioStarInteraction;
    BlockFireballInteraction BlockFireballInteraction;
    BlockInteraction MarioBlockInteraction;

    public void iterateListInteractions(List<IEntity> entities)
    {
        int item1 = 0;
        int item2 = 1;
        if(entities.Count > 1)
        {
            while (item1 < entities.Count  &&  item2 < entities.Count )
            {
                handleInteraction(entities, item1, item2);
                item1++;
                item2++;
            }
        }
    }
    public void handleInteraction(List<IEntity> entities, int index1, int index2)
    {

        /*Should determine the interactionType of two entities and call the appropriate method */
        IEntity item1 = entities[index1];
        IEntity item2 = entities[index2];

        //System.Diagnostics.Debug.WriteLine(item1.GetType() == typeof(Goomba));
        if (ContainsEnemy(entities, index1) && item2.GetType() == typeof(Mario))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item1, (Mario)item2, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()));
            EnemyMarioInteraction.Update();
        }
        else if (item1.GetType() == typeof(Mario) && ContainsEnemy(entities, index2))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item2, (Mario)item1, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()));
            EnemyMarioInteraction.Update();
        }

        else if (ContainsEnemy(entities, index1) && item2.GetType() == typeof(Fireball))
        {
            EnemyFireballInteraction = new EnemyFireballInteraction((Fireball)item2, (ISpriteEnemy)item1, entities);
            EnemyFireballInteraction.update();
        }
        else if (ContainsEnemy(entities, index2) && item1.GetType() == typeof(Fireball))
        {
            EnemyFireballInteraction = new EnemyFireballInteraction((Fireball)item1, (ISpriteEnemy)item2, entities);
            EnemyFireballInteraction.update();
        }

        if (ContainsEnemy(entities, index1) && item2.GetType() != typeof(Mario))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item1, item2);
            OtherEnemyInteraction.Update();
        }
        if (ContainsEnemy(entities, index2) && item1.GetType() != typeof(Mario))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item2, item1);
            OtherEnemyInteraction.Update();
        }
        //Item interaction
        if (item1.GetType() == typeof(Star) && item2.GetType() == typeof(Mario))
        {
            MarioStarInteraction = new MarioStarInteraction((Mario)item2, (Star)item1);
            MarioStarInteraction.update();
            //entities.RemoveAt(index1);
        }
        else if (item1.GetType() == typeof(Mario) && item2.GetType() == typeof(Star))
        {
            MarioStarInteraction = new MarioStarInteraction((Mario)item1, (Star)item2);
            MarioStarInteraction.update();
            //entities.RemoveAt(index2);
        }
        if (item1.GetType() == typeof(Fire) && item2.GetType() == typeof(Mario))
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item2, (Fire)item1);
            MarioFirePowerInteraction.update();
            //entities.RemoveAt(index1);
        }
        else if (item2.GetType() == typeof(Fire) && item1.GetType() == typeof(Mario))
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item1, (Fire)item2);
            MarioFirePowerInteraction.update();
           //// entities.RemoveAt(index2);
        }
        if (item1.GetType() == typeof(Mushroom) && item2.GetType() == typeof(Mario))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item2, (Mushroom)item1);
            MarioMushroomInteraction.update();
            //entities.RemoveAt(index1);
        }
        else if (item1.GetType() == typeof(Mario) && item1.GetType() == typeof(Mushroom))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item1, (Mushroom)item2);
            MarioMushroomInteraction.update();
            //entities.RemoveAt(index2);
        }
        if (item1.GetType() == typeof(Mario) && ContainsBlock(entities, index2))
        {
            //handle block interaction
            MarioBlockInteraction = new BlockInteraction((Mario)item1, (IBlock)item2);
            MarioBlockInteraction.update();
        }
        else if (ContainsBlock(entities, index1) && item2.GetType() == typeof(Mario))
        {
            MarioBlockInteraction = new BlockInteraction((Mario)item1, (IBlock)item2);
            MarioBlockInteraction.update();
        }
        //[...]
    }
    public Rectangle getRectangle(List<IEntity> Entities, int index)
    {
        IEntity entity = Entities[index];
        Rectangle rectangle = new Rectangle();
        rectangle = entity.GetDestination();
        return rectangle;
    }
    public void Compare(List<IEntity> entities, Rectangle camera)
    {
        if (entities.Count > 1)
        {
            Rectangle firstEntity = entities[0].GetDestination();
            Rectangle secondEntity = entities[1].GetDestination();
            for (int i = 0; (i < entities.Count) && (firstEntity.X <= (camera.Width + camera.X)); i++)
            {
                firstEntity = entities[i].GetDestination();
                for (int j = i+1; (j < entities.Count) && (secondEntity.X <= (camera.Width + camera.X)); j++)
                {
                    secondEntity = entities[j].GetDestination();
                    if (firstEntity.Intersects(secondEntity))
                    {
                        handleInteraction(entities, i, j);
                    } else
                    {
                        j = entities.Count;
                    }
                }
            }
        }

    }
}
