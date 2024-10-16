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


    EnemyMarioInteraction EnemyMarioInteraction;
    OtherEnemyInteraction OtherEnemyInteraction;
    //Pass some list
    //Sweep should 
    public void handleInteraction(List<IEntity> entities, int index1, int index2)
    {

        /*Should determine the interactionType of two entities and call the appropriate method */
        IEntity item1 = entities[index1];
        IEntity item2 = entities[index2];
        Rectangle overlap = item1.GetDestination();
        //soverlap.Intersect(item2.GetDestination());

        if (item1.GetType() == typeof(ISpriteEnemy) && item2.GetType() == typeof(Mario))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item1, (Mario)item2, overlap);
        } else if (item1.GetType() == typeof(Mario) && item2.GetType() == typeof(ISpriteEnemy))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item2, (Mario)item1, overlap);
        } else if (item1.GetType() == typeof(ISpriteEnemy))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item1);
        } else if (item2.GetType() == typeof(ISpriteEnemy))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item2);
        }



        if (item1.GetType() == typeof(FirePower) && item2.GetType() == typeof(Mario) || item1.GetType() == typeof(Mario) && item1.GetType() == typeof(FirePower))
        {
            //handle firePower interaction
        }
        if (item1.GetType() == typeof(MushroomPower) && item2.GetType() == typeof(Mario) || item1.GetType() == typeof(Mario) && item1.GetType() == typeof(MushroomPower))
        {
            //handle mushroomPower interaction
        }
        if (item1.GetType() == typeof(BlockObject) && item2.GetType() == typeof(Mario) || item1.GetType() == typeof(Mario) && item1.GetType() == typeof(BlockObject))
        {
            //handle block interaction
            //new BlockInteraction(item1, item2);
        }
        //[...]
    }
    public Rectangle getRectangle(List<IEntity> Entities, int index)
    {
        IEntity entity = Entities[index];
        Rectangle rectangle = new Rectangle();
       // rectangle = entity.GetDestinationRectangle;
        return rectangle;
    }
    public Boolean intersects(List<IEntity> entities, int index1, int index2)
    {
        Boolean intersects = false;
       // if (entities[index1].getRectangle.IntersectsWith(entitities[index2]){
       //     intersects = true;
       // }
            return intersects;
    }
    public void Compare(List<IEntity> entities)
    {

        /*This 
        //mario, item, block, enemy
        /*
          Rectangle rectangle = new Rectangle();
          rectangle.IntersectsWith();
          returns true or false
          
          list.ofType<>();
         */
        /*if(mario && item || item && mario)
            send to mario or item command
        */
        /*if(mario && block || block && mario)
            send to mario or block command
        */
        /*if(mario && enemy || enemy && mario)
            send to mario or enemy command
        */ //DONE ABOVE IN INTERACTION TYPE METHOD

        //if(item && item || item && block || item && enemy || enemy && enemy || enemy && block) 
        //These should all act the same, so else?
        //Rectangle rectangle = new Rectangle(0,0,0,0);
        //Rectangle r2 = rectangle;
        //r2.Intersect(Some r3)
        //Get's the area that is intersected and replaces r2. If r2 is rectangle. idk.
        
    }
}
