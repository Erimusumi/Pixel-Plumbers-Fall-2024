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
    EnemyFireballInteraction EnemyFireballInteraction;
    MarioFirePowerInteraction MarioFirePowerInteraction;
    MarioMushroomInteraction MarioMushroomInteraction;

    //Pass some list
    //Sweep should 
    public void handleInteraction(List<IEntity> entities, int index1, int index2)
    {

        /*Should determine the interactionType of two entities and call the appropriate method */
        IEntity item1 = entities[index1];
        IEntity item2 = entities[index2];

        //System.Diagnostics.Debug.WriteLine(item1.GetType() == typeof(Goomba));
        if (item1.GetType() == typeof(ISpriteEnemy) && item2.GetType() == typeof(Mario))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item1, (Mario)item2, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()));
        }
        else if (item1.GetType() == typeof(Mario) && item2.GetType() == typeof(ISpriteEnemy))
        {
            EnemyMarioInteraction = new EnemyMarioInteraction((ISpriteEnemy)item2, (Mario)item1, Rectangle.Intersect(item1.GetDestination(), item2.GetDestination()));
        }
        if (item1.GetType() == typeof(Goomba2) && item2.GetType() != typeof(Mario))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item1, item2);
            OtherEnemyInteraction.update();
        }
        if (item2.GetType() == typeof(Goomba) && item1.GetType() != typeof(Mario))
        {
            OtherEnemyInteraction = new OtherEnemyInteraction((ISpriteEnemy)item2, item1);
            OtherEnemyInteraction.update();
        }



        if (item1.GetType() == typeof(FirePower) && item2.GetType() == typeof(Mario)  )
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item2, (Fire)item1);
            MarioFirePowerInteraction.update(); 
        }
        else if (item1.GetType() == typeof(Mario) && item1.GetType() == typeof(FirePower))
        {
            MarioFirePowerInteraction = new MarioFirePowerInteraction((Mario)item2,(Fire)item1);
            MarioFirePowerInteraction.update(); 
        }
        if (item1.GetType() == typeof(Mushroom) && item2.GetType() == typeof(Mario))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item2,(Mushroom)item1);
            MarioMushroomInteraction.update();
        }
        else if (item1.GetType() == typeof(Mario) && item1.GetType() == typeof(MushroomPower))
        {
            MarioMushroomInteraction = new MarioMushroomInteraction((Mario)item1, (Mushroom)item2);
            MarioMushroomInteraction.update();
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
