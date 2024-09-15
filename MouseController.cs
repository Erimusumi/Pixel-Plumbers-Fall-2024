using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace cse3902
{
    public class MouseController: IController
    {
        List<(Rectangle, int, ICommand)> commands;
        public MouseController() { 
            commands = new List<(Rectangle, int, ICommand)>();
        }
        public void addCommand(Rectangle rectangle, int buttonPress, ICommand command)
        {
            commands.Add((rectangle, buttonPress, command));
        }
        public void Update()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = Mouse.GetState().Position;

            foreach (var command in commands)
            {
                if (command.Item2 == 1)
                { // check if left button is pressed
                    if (command.Item1.Contains(mousePosition) && mouseState.LeftButton == ButtonState.Pressed)
                    {
                        command.Item3.Execute();
                    }
                }
                else if (command.Item2 == 2)
                {
                    if (command.Item1.Contains(mousePosition) && mouseState.RightButton == ButtonState.Pressed)
                    {
                        command.Item3.Execute();
                    }
                }
            }
        
        }


           
    }
}
