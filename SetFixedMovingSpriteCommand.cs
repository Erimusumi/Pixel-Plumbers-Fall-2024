using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class SetFixedMovingSpriteCommand: ICommand
    {
        private Game1 game;
        public SetFixedMovingSpriteCommand(Game1 game) { 
            this.game = game;  
        }
        public void Execute()
        {
            game.currentSprite = 3;
        }
    }
}
