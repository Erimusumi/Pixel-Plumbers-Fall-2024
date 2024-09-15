using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class SetAnimatedSpriteCommand: ICommand
    {
        Game1 game;
        public SetAnimatedSpriteCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentSprite = 2;
        }
    }
}
