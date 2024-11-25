using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMarioSpriteMachine
{
    public ICharacter UpdatePlayerSprite(PlayerStateMachine marioStateMachine, Texture2D texture);
}
