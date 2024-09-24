using Microsoft.Xna.Framework.Graphics;
using System;

public interface ISpriteEnemy
{
	void changeDirection();
	void beStomped();
	void beFlipped();
	void Updates();
	void Draw(SpriteBatch sb, Texture2D Texture);

}
