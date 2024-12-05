using Pixel_Plumbers_Fall_2024;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

public class DisableScreenCommand : ICommand
{
    Dictionary<Rectangle, ICommand> list;
    MouseController gameMouseController;
    public DisableScreenCommand(Dictionary<Rectangle, ICommand> list, MouseController gameMouseController, Rectangle levelRec)
    {
        this.list = list;
        this.gameMouseController = gameMouseController;
        gameMouseController.RemoveCommand(levelRec);
    }
    public void Execute()
    {
        foreach (var item in list)
        {
            gameMouseController.RemoveCommand(item.Key);
        }
    }
}