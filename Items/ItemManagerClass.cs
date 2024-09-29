using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
public interface IitemManager
{
    void updateCurrentItem(int numItems, int[] itemArray)
    { 

    }
}
public class itemManager : IitemManager
{
    void updateCurrentItem(int currentItem, int[] itemArray)
    {
        int numItems = itemArray.Length;
        var kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.U))
        {
            if (currentItem == 0)
            {
                currentItem = numItems - 1;
            }
            else
            {
                currentItem--;
            }

        }
        if (kstate.IsKeyDown(Keys.I))
        {
            if (currentItem == (numItems - 1))
            {
                currentItem = 0;
            }
            else
            {
                currentItem++;
            }
        }

    }
    void drawCurrentItem(int currentItem, int[] itemArray, SpriteBatch spriteBatch)
    {
        if (currentItem == 0)
        {
            itemArray[0];
        }else if(currentItem == 1)
        {
            
        }else if(currentItem == 2)
        {

        }else if(currentItem == 3)
        {

        }
    }
}

