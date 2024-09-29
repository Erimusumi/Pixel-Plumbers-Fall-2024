using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;
public interface IitemManager
{
    void updateCurrentItem(int curr, int num);
}
public class itemManager : IitemManager
{
    public void updateCurrentItem(int currentItem, int numItems)
    {
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
}

