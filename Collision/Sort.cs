using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Sort
{
    int cameraX, cy, cw, ch;
    Rectangle start;
    Rectangle next;
    int holdElementNumber = 0;
    int entered = 0;
    int startX = 0, sy, sw, sh;
    int nextX = 0, ny, nw, nh;
    int smallestX = 0;
    public void Add(List<IEntity> objects, IEntity newObject)
    {
        objects.Add(newObject);
    }

    public void Remove(List<IEntity> objects, IEntity objToRemove)
    {
        if (!objects.Remove(objToRemove))
        {
            //Error: unable to remove object from collision detection list.
            string objName = objToRemove.ToString();
            Console.WriteLine("Unable to remove from collision detection list: " + objName);
            Environment.Exit(50);
        }
    }
    //Assume the list has at least 2 elements, besides a floor at [0]
    //[30, 10, 20...]
    //[20, 10, 30...]
    //[30, 20, 10...]
    //[20, 30, 10...]
    public void SortList(List<IEntity> objects, Rectangle camera)
    {
        camera.Deconstruct(out cameraX, out cy, out cw, out ch);
        for (int i = 0; (i < objects.Count) && (startX < cameraX); i++)
        {
            smallestX = cameraX;
            start = objects[i].GetDestination();
            for(int j = 1; (j < objects.Count) && (i != j) && (nextX < cameraX); j++)
            {
                next = objects[j].GetDestination();
                start.Deconstruct(out startX, out sy, out sw, out sh);
                next.Deconstruct(out nextX, out ny, out nw, out nh);
                if ((nextX < startX) && (nextX < smallestX))
                {
                    smallestX = nextX;
                    holdElementNumber = j;
                    entered++;
                }
            }
            if (entered > 0)
            {
                IEntity holdE = objects[holdElementNumber];
                objects[holdElementNumber] = objects[i];
                objects[i] = holdE;
            }
            entered = 0;

        }

    }
    public void clearList(List<Object> objects)
    {
        objects.Clear();

    }
}
