using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pixel_Plumbers_Fall_2024;


public class SetCrouchCommand : ICommand
{
    private Game1 game;

    public SetCrouchCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.Mario.Crouch();
    }

    public void Unexecute()
    {
        game.Mario.Stop();
    }
}

