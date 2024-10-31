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
    private CardScore player1;
    private CardScore player2;
    public BlackJackSprites(Texture2D TextureTable, Texture2D TextureTop, Texture2D TextureCards, SpriteFont font)
    {
        cardRectangles.Add(next);
        Texture = TextureTable;
        this.TextureTable = TextureTable;
        this.TextureTop = TextureTop;
        this.TextureCards = TextureCards;
        destinationRectangle = new Rectangle(25, 375, 50, 46);
        player1 = new CardScore(0, font);
        player2 = new CardScore(1, font);
    }

    private Rectangle sourceRectangle;
    private Rectangle destinationRectangle;
    private float rotation = 0f;
    private const float pi180 = 3.14159265f / 180f;

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

    //Rotations
    private float rotation1;
    private float rotation2;
    private float rotation3;
    private float rotation4;
    private float rotation5;
    private float rotation6;
    private float rotation7;
    private float rotation8;
    private float rotation9;
    private float rotation10;
    private float rotation11;

    //Card Sources
    private Rectangle sourceCard1P2;
    private Rectangle sourceCard2P2;
    private Rectangle sourceCard3P2;
    private Rectangle sourceCard4P2;
    private Rectangle sourceCard5P2;
    private Rectangle sourceCard6P2;
    private Rectangle sourceCard7P2;
    private Rectangle sourceCard8P2;
    private Rectangle sourceCard9P2;
    private Rectangle sourceCard10P2;
    private Rectangle sourceCard11P2;

    //Card Destinations
    private Rectangle destinationCard1P2;
    private Rectangle destinationCard2P2;
    private Rectangle destinationCard3P2;
    private Rectangle destinationCard4P2;
    private Rectangle destinationCard5P2;
    private Rectangle destinationCard6P2;
    private Rectangle destinationCard7P2;
    private Rectangle destinationCard8P2;
    private Rectangle destinationCard9P2;
    private Rectangle destinationCard10P2;
    private Rectangle destinationCard11P2;

    //Rotations
    private float rotation1P2;
    private float rotation2P2;
    private float rotation3P2;
    private float rotation4P2;
    private float rotation5P2;
    private float rotation6P2;
    private float rotation7P2;
    private float rotation8P2;
    private float rotation9P2;
    private float rotation10P2;
    private float rotation11P2;

    private int Cwidth = 107;
    private int Cheight = 170;
    private int CFinalWidth = 75;
    private int CFinalHeight = 110;
    private int cardCount = 0;

    private Random randomX = new Random();
    private Random randomY = new Random();
    private Random randomRotation = new Random();
    private Random negative = new Random();

    private void nextCard()
    {
        next = new Rectangle(0, 0, 0, 0);
        while (cardRectangles.Contains(next) && (cardRectangles.Count < 53))
        {
            next = new Rectangle(randomX.Next(13) * Cwidth, randomY.Next(4) * Cheight, Cwidth, Cheight);
        }
        rotation = randomRotation.Next(12) * pi180;
        if (negative.Next(2) == 1)
        {
            rotation = -rotation;
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
                destinationCard1 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard1 = next;
                rotation1 = rotation;
                break;
            case 1:
                destinationCard2 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard2 = next;
                rotation2 = rotation;
                break;
            case 2:
                destinationCard3 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard3 = next;
                rotation3 = rotation;
                break;
            case 3:
                destinationCard4 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard4 = next;
                rotation4 = rotation;
                break;
            case 4:
                destinationCard5 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard5 = next;
                rotation5 = rotation;
                break;
            case 5:
                destinationCard6 = new Rectangle(100 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard6 = next;
                rotation6 = rotation;
                break;
            case 6:
                destinationCard7 = new Rectangle(105 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard7 = next;
                rotation7 = rotation;
                break;
            case 7:
                destinationCard8 = new Rectangle(105 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard8 = next;
                rotation8 = rotation;
                break;
            case 8:
                destinationCard9 = new Rectangle(105 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard9 = next;
                rotation9 = rotation;
                break;
            case 9:
                destinationCard10 = new Rectangle(105 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard10 = next;
                rotation10 = rotation;
                break;
            case 10:
                destinationCard11 = new Rectangle(105 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard11 = next;
                rotation11 = rotation;
                break;
            case 11:
                destinationCard1P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard1P2 = next;
                rotation1P2 = rotation;
                break;
            case 12:
                destinationCard2P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard2P2 = next;
                rotation2P2 = rotation;
                break;
            case 13:
                destinationCard3P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard3P2 = next;
                rotation3P2 = rotation;
                break;
            case 14:
                destinationCard4P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard4P2 = next;
                rotation4P2 = rotation;
                break;
            case 15:
                destinationCard5P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard5P2 = next;
                rotation5P2 = rotation;
                break;
            case 16:
                destinationCard6P2 = new Rectangle(220 + (20 * cardCount), 150, CFinalWidth, CFinalHeight);
                sourceCard6P2 = next;
                rotation6P2 = rotation;
                break;
            case 17:
                destinationCard7P2 = new Rectangle(225 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard7P2 = next;
                rotation7P2 = rotation;
                break;
            case 18:
                destinationCard8P2 = new Rectangle(225 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard8P2 = next;
                rotation8P2 = rotation;
                break;
            case 19:
                destinationCard9P2 = new Rectangle(225 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard9P2 = next;
                rotation9P2 = rotation;
                break;
            case 20:
                destinationCard10P2 = new Rectangle(225 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard10P2 = next;
                rotation10P2 = rotation;
                break;
            case 21:
                destinationCard11P2 = new Rectangle(225 + (20 * (cardCount - 6)), 180, CFinalWidth, CFinalHeight);
                sourceCard11P2 = next;
                rotation11P2 = rotation;
                break;
        }
        //score.scoreCalc(next.X);
        if (cardCount < 11)
        {
            player1.scoreCalc(next.X);
        }
        else if (cardCount >= 11 && cardCount < 22)
        {
            player2.scoreCalc(next.X);
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

        if (destinationRectangle.Width == 800)
        {
            sb.Draw(TextureCards, destinationCard1, sourceCard1, Color.White, rotation1, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard2, sourceCard2, Color.White, rotation2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard3, sourceCard3, Color.White, rotation3, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard4, sourceCard4, Color.White, rotation4, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard5, sourceCard5, Color.White, rotation5, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard6, sourceCard6, Color.White, rotation6, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard7, sourceCard7, Color.White, rotation7, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard8, sourceCard8, Color.White, rotation8, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard9, sourceCard9, Color.White, rotation9, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard10, sourceCard10, Color.White, rotation10, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard11, sourceCard11, Color.White, rotation11, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);

            //Player 2
            sb.Draw(TextureCards, destinationCard1P2, sourceCard1P2, Color.White, rotation1P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard2P2, sourceCard2P2, Color.White, rotation2P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard3P2, sourceCard3P2, Color.White, rotation3P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard4P2, sourceCard4P2, Color.White, rotation4P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard5P2, sourceCard5P2, Color.White, rotation5P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard6P2, sourceCard6P2, Color.White, rotation6P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard7P2, sourceCard7P2, Color.White, rotation7P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard8P2, sourceCard8P2, Color.White, rotation8P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard9P2, sourceCard9P2, Color.White, rotation9P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard10P2, sourceCard10P2, Color.White, rotation10P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);
            sb.Draw(TextureCards, destinationCard11P2, sourceCard11P2, Color.White, rotation11P2, new Vector2(Cwidth / 2, Cheight / 2), SpriteEffects.None, 0f);

            player1.Draw(sb);
            player2.Draw(sb);
        }

    }

}
