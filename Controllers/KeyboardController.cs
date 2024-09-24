using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

public class KeyboardController : IController
{
    Dictionary<Keys, ICommand> KeyBinds;
    public KeyboardController()
    {
        KeyBinds = new Dictionary<Keys, ICommand>();
    }

    public void addCommand(Keys key, ICommand command)
    {
        KeyBinds.Add(key, command);
    }

    public void Update(GameTime gameTime)
    {
        var keysPressed = Keyboard.GetState().GetPressedKeys();

        foreach (var key in keysPressed)
        {
            if (KeyBinds.ContainsKey(key))
            {
                KeyBinds[key].Execute();
            }
        }
    }
}
