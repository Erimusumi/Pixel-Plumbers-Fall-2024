using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public interface IPlayer : IEntity
{
    public void MoveRight();
    public void MoveLeft();
    public void Jump();
    public void Crouch();
    public bool HasStar();
    public void TakeDamage();
    public void SetVelocityY(float vY);
    public void SetVelocityX(float vX);
}
