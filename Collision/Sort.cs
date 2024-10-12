using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pixel_Plumbers_Fall_2024;

public class Sort
{
    public void Add(List<IEntity> objects, IEntity newObject)
    {
        objects.Add(newObject);
    }

    public void Remove(List<Object> objects, Object objToRemove)
    {
        if (!objects.Remove(objToRemove))
        {
            //Error: unable to remove object from collision detection list.
            string objName = objToRemove.ToString();
            Console.WriteLine("Unable to remove from collision detection list: " + objName);
            Environment.Exit(50);
        }
    }

    public void SortList(List<Object> objects)
    {


    }


}
