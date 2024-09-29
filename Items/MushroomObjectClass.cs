using System;
using System.Runtime.InteropServices;
public interface IMushroomObject
{
    void mushroom();
    Boolean idleState();
    Boolean collectedState();




}
public class MushroomObject : IMushroomObject
{
    private Boolean idle;
    private Boolean collected;

    public void mushroom()
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