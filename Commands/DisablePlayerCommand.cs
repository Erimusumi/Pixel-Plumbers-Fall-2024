using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

public class DisablePlayerCommand : IPlayerCommand
{
    Dictionary<Keys, IPlayerCommand> commands;
    PlayerMovementController playerMovementController;
    public DisablePlayerCommand(PlayerMovementController playerMovementController)
    {
        this.playerMovementController = playerMovementController;
    }

    public void Execute()
    {
        commands = playerMovementController.GetCommands();
        playerMovementController.SetCommands(new Dictionary<Keys, IPlayerCommand>());
        playerMovementController.addCommand(Keys.D0, this);
    }

    public void Unexecute()
    {
        playerMovementController.SetCommands(commands);
    }
}
