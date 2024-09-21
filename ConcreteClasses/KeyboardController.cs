using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

public class KeyboardController : IKeyboardController
{
    Dictionary<Keys, ICommand> keyCommands;
    public KeyboardController()
    {
        keyCommands = new Dictionary<Keys, ICommand>();
    }
    public void update()
    {
        var keysPressed = Keyboard.GetState().GetPressedKeys();
        foreach (var key in keysPressed)
        {
            if (keyCommands.ContainsKey(key))
            {
            }
        }
    }
}