using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

public class PlayerMovementController : IController
{
    Dictionary<Keys, IPlayerCommand> KeyBinds;
    KeyboardState previousKeyState;

    public PlayerMovementController()
    {
        KeyBinds = new Dictionary<Keys, IPlayerCommand>();
        previousKeyState = Keyboard.GetState();
    }

    public void addCommand(Keys key, IPlayerCommand command)
    {
        KeyBinds.Add(key, command);
    }

    public Dictionary<Keys, IPlayerCommand> GetCommands()
    {
        return KeyBinds;
    }

    public void SetCommands(Dictionary<Keys, IPlayerCommand> commands)
    {
        KeyBinds = commands;
    }

    public void Update()
    {
        KeyboardState currentKeyState = Keyboard.GetState();
        Keys[] keysPressed = currentKeyState.GetPressedKeys();
        Keys[] previouslyPressedKeys = previousKeyState.GetPressedKeys();

        foreach (var key in keysPressed)
        {
            if (KeyBinds.ContainsKey(key))
            {
                KeyBinds[key].Execute();
            }
        }
        foreach (var key in previouslyPressedKeys)
        {
            if (!keysPressed.Contains(key) && KeyBinds.ContainsKey(key))
            {
                KeyBinds[key].Unexecute();
            }
        }
        previousKeyState = currentKeyState;
    }
}
