using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public interface ISpriteEnemy : IEntity
{
	void changeDirection();
	void beStomped();
	void beFlipped();
	void Updates();
    void Draw(SpriteBatch sb, Texture2D Texture);

	void setGroundPosition(float x);
	public bool GetIsOnGround();
	public void SetIsOnGround(bool val);

}
