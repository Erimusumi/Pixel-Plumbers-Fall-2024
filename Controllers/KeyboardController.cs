using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class KeyboardController : IKeyboardController
{
    private ICommand MyCommands;
    public Dictionary<Keys, ICommand> keyCommands;

    public KeyboardController(Game game1)
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