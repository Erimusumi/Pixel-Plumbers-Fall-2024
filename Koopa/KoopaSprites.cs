using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pixel_Plumbers_Fall_2024;


public class KoopaSprites
{
    KoopaFields vars;
    public KoopaSprites(int _posX, int _posY)
    {
        vars = new KoopaFields(_posX, _posY);
    }
    KoopaLeftLogic left = new KoopaLeftLogic();
    KoopaRightLogic right = new KoopaRightLogic();
    KoopaStompedLogic stomped = new KoopaStompedLogic();
    KoopaFlippedLogic flipped = new KoopaFlippedLogic();

    public void LeftLogic()
	{
        left.Updates(vars);
    }
	public void RightLogic()
	{
        right.Updates(vars);
    }
	public void StompedLogic()
	{
        stomped.Updates(vars);
    }
    public void StompedTwiceLogicLeft()
    {
        vars.counter2 = -1;
        int holdHeight = vars.height;
        int holdLeftXOne = vars.leftXOne;
        int holdLeftXTwo = vars.leftXTwo;
        int holdrightY = vars.rightY;
        vars.height = 15;
        vars.leftXOne = 360;
        vars.leftXTwo = 360;
        vars.rightY = 5;
        this.LeftLogic();
        vars.height = holdHeight;
        vars.leftXOne = holdLeftXOne;
        vars.leftXTwo = holdLeftXTwo;
        vars.rightY = holdrightY;

    }
    public void StompedTwiceLogicRight()
    {
        vars.counter2 = -1;
        int holdHeight = vars.height;
        int holdRightXOne = vars.rightXOne;
        int holdRightXTwo = vars.rightXTwo;
        int holdrightY = vars.rightY;
        vars.height = 15;
        vars.rightXOne = 360;
        vars.rightXTwo = 360;
        vars.rightY = 5;
        this.RightLogic();
        vars.height = holdHeight;
        vars.rightXOne = holdRightXOne;
        vars.rightXTwo = holdRightXTwo;
        vars.rightY = holdrightY;

    }
    public void FlippedLogic()
	{
        flipped.Updates(vars);
    }

    public Rectangle GetDestination()
    {
        return vars.destinationRectangle;
    }

    public void Draw(SpriteBatch sb, Texture2D Texture)
	{
        sb.Begin();
        sb.Draw(Texture, vars.destinationRectangle, vars.sourceRectangle, Color.White, vars.rotation, new Vector2(vars.width / 2, vars.height / 2), SpriteEffects.None, 0f);
        sb.End();
    }
}
