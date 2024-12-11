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
    float time = 0;
    int doorDistance = 160;
    public  WinCutScene(IPlayer player, Rectangle currentPosition)
    {
        this.player1 = player;
        manager = new CutSceneManager(player);
    }
    public void Update(GameTime gameTime)
    {
        time += 1 /*(float)gameTime.ElapsedGameTime.TotalSeconds*/;
        //TODO: slow this down (timer)
        if (time > 1 && doorDistance > 0)
        {
            player1.SetPositionX(player1.GetDestination().X + 1);

            doorDistance--;
            time = 0;
        }
        if(doorDistance == 0)
        {
            player1.getStateMachine().MakeInvisible();
        }
    }
    public void play(GameTime gameTime)
    {
        stateMachine = player1.GetStateMachine();
        stateMachine.SetPlayerBig();
        manager.setPlayerPosition(6370, 380); 

       
            //time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            ////TODO: slow this down (timer)
            //if(time > 1)
            //{
            //    player1.SetPositionX(player1.GetDestination().X + 1);
            //    doorDistance--;
            //    time = 0;
            //}
            
        
        //TODO: mario vanishes into door
        //player1.GetStateMachine().MakeInvisible();

    }
}


