using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem 
{
    public void swapDirection();
    public void update();
    public void draw();
    public void destroy();
    public void roams();
    public void collect();
    public void idling();


}

