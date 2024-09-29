using Pixel_Plumbers_Fall_2024;
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
    public void draw(int currentItem, Texture2D itemsText, SpriteBatch sB,Vector2 position)
    {
        if (currentItem == 0)
        {
            StarPower sp = new StarPower(itemsText);
            sp.Draw(sB,position );
        }else if(currentItem == 1)
        {
            FirePower firePower = new FirePower(itemsText);
            firePower.Draw(sB,position); 

        }else if(currentItem == 2)
        {
            
        }
}

