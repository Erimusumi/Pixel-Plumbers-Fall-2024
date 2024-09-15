using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Input;

namespace cse3902
{
    public class KeyboardController: IController
    {
        Dictionary<Keys, ICommand> keyCommands;
        public KeyboardController() {
            keyCommands = new Dictionary<Keys, ICommand>();
        }

        public void addCommand(Keys key, ICommand command)
        {
            keyCommands.Add(key, command);
        }

        public void Update()
        {
            var keysPressed = Keyboard.GetState().GetPressedKeys();

            foreach (var key in keysPressed)
            {
                if (keyCommands.ContainsKey(key))
                {
                    keyCommands[key].Execute();
                }
            }
        }
    }
    
}
