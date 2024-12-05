using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CutSceneManager
{
    DisablePlayerCommand disableIPlayer;
    public CutSceneManager()
    {

    }
    public void moveRight(IPlayer player)
    {
        player.MoveRight();

    }
    public void moveLeft(IPlayer player)
    {
        player.MoveLeft();
    }

    public void setPlayerPosition(IPlayer player, int x, int y)
    {
        player.SetPositionX(x);
        player.SetPositionY(y);
    }

    public void disablePlayer()
    {
        disableIPlayer.Execute();
    }

}



