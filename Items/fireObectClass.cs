using Pixel_Plumbers_Fall_2024;
using System;
using System.Runtime.InteropServices;
public interface IFireObject
{
    void firePowerItem();
    Boolean idleState();
    Boolean collectedState();
}
public class firePower : IFireObject
{
    private Boolean idle;
    private Boolean collected;

    public void firePowerItem()
    {
        this.idle = false;
        this.collected = false;
    }
    public Boolean idleState()
    {
        return this.idle;
    }
    public Boolean collectedState()
    {

        return this.collected;
    }


}