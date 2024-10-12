using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Pixel_Plumbers_Fall_2024;

public class Sweep
{
    //Pass some list
    //Sweep should 
    public void getInteraction(List<Object> entities, int index1, int index2)
    {
        /*Should determine the interactionType of two entities and call the appropriate method */
        Object item1 = entities[index1];
        Object item2 = entities[index2];
        if (item1.GetType() == typeof(Goomba) && item2.GetType() == typeof(Mario) || item2.GetType() == typeof(Mario) && item1.GetType() == typeof(Goomba))
        {
            //handle goomba interaction
        }
        if (item1.GetType() == typeof(Koopa) && item2.GetType() == typeof(Mario) || item2.GetType() == typeof(Mario) && item1.GetType() == typeof(Koopa))
        {
            //handle koopa interaction
        }
        if (item1.GetType() == typeof(firePower) && item2.GetType() == typeof(Mario) || item2.GetType() == typeof(Mario) && item1.GetType() == typeof(firePower))
        {
            //handle firePower interaction
        }
        if (item1.GetType() == typeof(MushroomPower) && item2.GetType() == typeof(Mario) || item2.GetType() == typeof(Mario) && item1.GetType() == typeof(MushroomPower))
        {
            //handle mushroomPower interaction
        }
        if (item1.GetType() == typeof(BlockObject) && item2.GetType() == typeof(Mario) || item2.GetType() == typeof(Mario) && item1.GetType() == typeof(BlockObject))
        {
            //handle block interaction
        }
        //[...]


    }
    public void Compare(List<Object> entities)
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
