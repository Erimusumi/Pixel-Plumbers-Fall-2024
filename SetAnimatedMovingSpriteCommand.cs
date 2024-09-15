using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class SetAnimatedMovingSpriteCommand: ICommand
    {
        private Game1 game;
        public SetAnimatedMovingSpriteCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentSprite = 4;
        }
    }
}
