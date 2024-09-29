using System;
using System.Runtime.InteropServices;
public interface IStarObject
{
    void star();
    Boolean idleState();
    Boolean collectedState();




}
public class StarObject : IStarObject
{
    private Boolean idle;
    private Boolean collected;

    public void star()
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

