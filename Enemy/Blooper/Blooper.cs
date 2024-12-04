using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;

public class Blooper : ISpriteEnemy
{
    private BlooperStateMachine stateMachine;
    public Blooper(int posX, int posY, IPlayer mario, IPlayer luigi)
    {
        stateMachine = new BlooperStateMachine(posX, posY, mario, luigi);
    }
    public Boolean IsFlipped()
    {
        return stateMachine.IsFlipped();
    }
    public void changeDirection()
    {
        stateMachine.changeDirection();
    }

    public void beStomped()
    {
        stateMachine.beStomped();
    }
    public void beFlipped()
    {
        stateMachine.beFlipped();
    }

    public void Updates()
    {
        stateMachine.Update();
    }

    public Rectangle GetDestination()
    {
        return stateMachine.GetDestination();
    }

    public void Draw(SpriteBatch sb, Texture2D Texture)
    {
        stateMachine.Draw(sb, Texture);
    }
    public void setGroundPosition(float x)
    {

    }

}
