using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class BlackJackSprites
{
    Texture2D Texture;
    Texture2D TextureTable;
    Texture2D TextureTop;
    Texture2D TextureCards;
    Rectangle next = new Rectangle(0, 0, 0, 0);
    private List<Rectangle> cardRectangles = new List<Rectangle>();
    public BlackJackSprites(Texture2D TextureTable, Texture2D TextureTop, Texture2D TextureCards)
    {
        cardRectangles.Add(next);
        Texture = TextureTable;
        this.TextureTable = TextureTable;
        this.TextureTop = TextureTop;
        this.TextureCards = TextureCards;
        destinationRectangle = new Rectangle(25, 375, 50, 46);
    }

    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;

    //Card Sources
    private Rectangle sourceCard1;
    private Rectangle sourceCard2;
    private Rectangle sourceCard3;
    private Rectangle sourceCard4;
    private Rectangle sourceCard5;
    private Rectangle sourceCard6;
    private Rectangle sourceCard7;
    private Rectangle sourceCard8;
    private Rectangle sourceCard9;
    private Rectangle sourceCard10;
    private Rectangle sourceCard11;

    //Card Destinations
    private Rectangle destinationCard1;
    private Rectangle destinationCard2;
    private Rectangle destinationCard3;
    private Rectangle destinationCard4;
    private Rectangle destinationCard5;
    private Rectangle destinationCard6;
    private Rectangle destinationCard7;
    private Rectangle destinationCard8;
    private Rectangle destinationCard9;
    private Rectangle destinationCard10;
    private Rectangle destinationCard11;

    private int Cwidth = 107;
    private int Cheight = 170;
    private int CFinalWidth = 75;
    private int CFinalHeight = 110;
    private int cardCount = 0;

    Random randomX = new Random();
    Random randomY = new Random();

    private void nextCard()
    {
        next = new Rectangle(0, 0, 0, 0);
        while (cardRectangles.Contains(next) && (cardRectangles.Count < 53))
        {
            next = new Rectangle(randomX.Next(13) * Cwidth, randomY.Next(4) * Cheight, Cwidth, Cheight);
        }
        cardRectangles.Add(next);
    }

    public void table()
    {
        Texture = TextureTable;
        sourceRectangle = new Rectangle(0, 0, 248, 231);
        destinationRectangle = new Rectangle(25, 375, 50, 46);
    }
    public void tabletop()
    {
        Texture = TextureTop;
        sourceRectangle = new Rectangle(0, 0, 400, 282);
        destinationRectangle = new Rectangle(0, 0, 800, 480);
    }

    public void cards()
    {
        nextCard();

        switch (cardCount)
        {
            case 0:
                destinationCard1 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard1 = next;
                break;
            case 1:
                destinationCard2 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard2 = next;
                break;
            case 2:
                destinationCard3 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard3 = next;
                break;
            case 3:
                destinationCard4 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard4 = next;
                break;
            case 4:
                destinationCard5 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard5 = next;
                break;
            case 5:
                destinationCard6 = new Rectangle(80 + (20 * cardCount), 100, CFinalWidth, CFinalHeight);
                sourceCard6 = next;
                break;
            case 6:
                destinationCard7 = new Rectangle(85 + (20 * (cardCount - 6)), 130, CFinalWidth, CFinalHeight);
                sourceCard7 = next;
                break;
            case 7:
                destinationCard8 = new Rectangle(85 + (20 * (cardCount - 6)), 130, CFinalWidth, CFinalHeight);
                sourceCard8 = next;
                break;
            case 8:
                destinationCard9 = new Rectangle(85 + (20 * (cardCount - 6)), 130, CFinalWidth, CFinalHeight);
                sourceCard9 = next;
                break;
            case 9:
                destinationCard10 = new Rectangle(85 + (20 * (cardCount - 6)), 130, CFinalWidth, CFinalHeight);
                sourceCard10 = next;
                break;
            case 10:
                destinationCard11 = new Rectangle(85 + (20 * (cardCount - 6)), 130, CFinalWidth, CFinalHeight);
                sourceCard11 = next;
                break;
        }
        cardCount++;
    }

    public Rectangle DestinationRectangle()
    {
        return destinationRectangle;
    }

    public void Draw(SpriteBatch sb)
    {
        sb.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        sb.Draw(TextureCards, destinationCard1, sourceCard1, Color.White);
        sb.Draw(TextureCards, destinationCard2, sourceCard2, Color.White);
        sb.Draw(TextureCards, destinationCard3, sourceCard3, Color.White);
        sb.Draw(TextureCards, destinationCard4, sourceCard4, Color.White);
        sb.Draw(TextureCards, destinationCard5, sourceCard5, Color.White);
        sb.Draw(TextureCards, destinationCard6, sourceCard6, Color.White);
        sb.Draw(TextureCards, destinationCard7, sourceCard7, Color.White);
        sb.Draw(TextureCards, destinationCard8, sourceCard8, Color.White);
        sb.Draw(TextureCards, destinationCard9, sourceCard9, Color.White);
        sb.Draw(TextureCards, destinationCard10, sourceCard10, Color.White);
        sb.Draw(TextureCards, destinationCard11, sourceCard11, Color.White);

    }

}
