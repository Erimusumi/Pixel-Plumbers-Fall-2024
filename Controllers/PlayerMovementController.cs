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

    public void Update()
    {
        KeyboardState currentKeyState = Keyboard.GetState();
        Keys[] keysPressed = currentKeyState.GetPressedKeys();
        Keys[] previouslyPressedKeys = previousKeyState.GetPressedKeys();

        // Execute commands for keys that are currently pressed
        foreach (var key in keysPressed)
        {
            if (KeyBinds.ContainsKey(key))
            {
                KeyBinds[key].Execute();
            }
        }
        // Unexecute commands for keys that were pressed in the previous state, but are not pressed anymore
        foreach (var key in previouslyPressedKeys)
        {
            if (!keysPressed.Contains(key) && KeyBinds.ContainsKey(key))
            {
                KeyBinds[key].Unexecute();  // Call Unexecute on key release
            }
        }
        previousKeyState = currentKeyState;
    }
}
