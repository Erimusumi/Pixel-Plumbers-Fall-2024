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
    int doorDistance = 180;
    public  WinCutScene(IPlayer player, Rectangle currentPosition)
    {
        this.player1 = player;
        manager = new CutSceneManager(player);
    }
    public void play()
    {
        stateMachine = player1.GetStateMachine();
        stateMachine.SetPlayerBig();
        manager.setPlayerPosition(6370, 380); 

        while (doorDistance >0)
        {
            //TODO: slow this down (timer)
            player1.SetPositionX(player1.GetDestination().X + 1);
            doorDistance--;
        }
        //TODO: mario vanishes into door
        //player1.MakeInvisible();

    }
}


