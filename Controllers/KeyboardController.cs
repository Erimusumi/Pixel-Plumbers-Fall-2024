using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Pixel_Plumbers_Fall_2024;
using Microsoft.Xna.Framework;

public class KeyboardController : IController
{
    Dictionary<Keys, ICommand> keyCommands;
    private Game1 game1;

    public KeyboardController(Game1 game1)
    {
        this.game1 = game1;
        keyCommands = new Dictionary<Keys, ICommand>();
    }

    public void addCommand(Keys key, ICommand command)
    {
        keyCommands.Add(key, command);
    }

    public void Update(GameTime gameTime)
    {
        var keysPressed = Keyboard.GetState().GetPressedKeys();

        foreach (var key in keysPressed)
        {
            if (keyCommands.ContainsKey(key))
            {
                keyCommands[key].Execute(game1);
            }
        }
    }
}

