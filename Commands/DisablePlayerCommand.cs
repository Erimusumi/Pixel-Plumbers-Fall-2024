using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
public class DisablePlayerCommand : ICommand
{
    Dictionary<Keys, IPlayerCommand> commands;
    PlayerMovementController playerMovementController;
    int count = 0;
    public DisablePlayerCommand(PlayerMovementController playerMovementController)
    {
        this.playerMovementController = playerMovementController;
        commands = playerMovementController.GetCommands();
    }

    public void Execute()
    {
        if (count == 0)
        {
            playerMovementController.SetCommands(new Dictionary<Keys, IPlayerCommand>());
            count++;
        } else
        {
            playerMovementController.SetCommands(commands);
            count = 0;
        }
    }
}
