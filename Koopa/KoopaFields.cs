using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class KoopaFields
{
    public Rectangle sourceRectangle;
    public Rectangle destinationRectangle;
    public int counter = -1;
    public int counter2 = -1;
    public int countEnd = 4000;
    public int countStart = 10;
    public int countMod = 10;
    public int posX = 480;
    public int posY = 400;
    public int scaleUp = 2;
    public int speed = 1;
    public int width = 16;
    public int height = 24;
    public int position = 480;
    public float rotation = 0f;

    public int leftXOne = 180;
    public int leftXTwo = 150;
    public int rightY = 0;
    public int rightXOne = 210;
    public int rightXTwo = 240;
}
