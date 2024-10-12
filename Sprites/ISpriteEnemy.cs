using Microsoft.Xna.Framework.Graphics;
using System;

public interface ISpriteEnemy : IEntity
{
	void changeDirection();
	void beStomped();
	void beFlipped();
	void Update();
	void Draw(SpriteBatch sb, Texture2D Texture);

}
