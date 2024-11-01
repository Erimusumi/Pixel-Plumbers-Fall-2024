using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class CardScore
{

    public CardScore()
    {

    }

    private int playerOneScoreOne = 0;
    private int playerTwoScoreTwo = 0;
    private int Cwidth = 107;

    public void scoreCalc(int Xval)
    {
        Xval = (Xval / Cwidth);
        switch (Xval)
        {
            case 0:
                if (playerOneScoreOne != playerTwoScoreTwo)
                {
                    playerTwoScoreTwo = playerOneScoreOne;
                }
                playerOneScoreOne++;
                playerTwoScoreTwo += 11;
                break;
            case 1:
                playerOneScoreOne += 2;
                playerTwoScoreTwo += 2;
                break;
            case 2:
                playerOneScoreOne += 3;
                playerTwoScoreTwo += 3;
                break;
            case 3:
                playerOneScoreOne += 4;
                playerTwoScoreTwo += 4;
                break;
            case 4:
                playerOneScoreOne += 5;
                playerTwoScoreTwo += 5;
                break;
            case 5:
                playerOneScoreOne += 6;
                playerTwoScoreTwo += 6;
                break;
            case 6:
                playerOneScoreOne += 7;
                playerTwoScoreTwo += 7;
                break;
            case 7:
                playerOneScoreOne += 8;
                playerTwoScoreTwo += 8;
                break;
            case 8:
                playerOneScoreOne += 9;
                playerTwoScoreTwo += 9;
                break;
            case 9:
                playerOneScoreOne += 10;
                playerTwoScoreTwo += 10;
                break;
            case 10:
                playerOneScoreOne += 10;
                playerTwoScoreTwo += 10;
                break;
            case 11:
                playerOneScoreOne += 10;
                playerTwoScoreTwo += 10;
                break;
            case 12:
                playerOneScoreOne += 10;
                playerTwoScoreTwo += 10;
                break;
        }
        System.Diagnostics.Debug.WriteLine("playerOneScoreOne = ");
        System.Diagnostics.Debug.WriteLine(playerOneScoreOne);
    }




}
