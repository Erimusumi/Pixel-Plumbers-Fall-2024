using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IItem 
{
    void swapDirection();
    void update();
    void draw();
    void destroy();
    void roams();
    void collect();
    void idling();


}

