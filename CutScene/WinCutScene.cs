using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using System.Threading.Tasks;


    public class WinCutScene: ICutScene
{
    IPlayer player1;
    IPlayer player2;
    Rectangle currentPosition;
    PlayerStateMachine stateMachine;
    CutSceneManager manager;
    int doorDistance = 190;
    public  WinCutScene(IPlayer player, Rectangle currentPosition)
    {
        this.player1 = player;
        manager = new CutSceneManager(player);
    }
    public void play()
    {
        stateMachine = player1.GetStateMachine();
        stateMachine.SetPlayerBig();
        manager.setPlayerPosition(6350, 380);

        while (doorDistance >0)
        {
            manager.moveRight();
            doorDistance--;
        }
        //mario vanishes

    }
}


