using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cse3902
{
    public class SetFixedSpriteCommand: ICommand
    {
        private Game1 game;
        public SetFixedSpriteCommand(Game1 game) {
            this.game = game;
        }
        public void Execute() {
            game.currentSprite = 1;        
        }
    }
}
